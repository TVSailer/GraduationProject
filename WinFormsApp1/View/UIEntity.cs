using Admin.View.Moduls.Event;
using Admin.View.ViewForm;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;



public class UIEntity<TEntity, TViewModel> : IView
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    protected readonly AdminMainView form;
    protected readonly ErrorProviderView errorProviderView;
    protected readonly ImagePanel<TEntity> imagePanel;
    public readonly TViewModel Context;

    protected List<FieldInfoUIAttribute> fieldInfo = new();
    protected List<ButtonInfoUIAttribute> buttonsInfo = new();

    public UIEntity(AdminMainView mainView, TViewModel viewModel)
    {
        form = mainView;

        Context = viewModel;

        if (Context is PropertyChange obj1)
            errorProviderView = new ErrorProviderView(obj1);
        else throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

        if (Context is ViewModelWithImages<TEntity> obj2)
            imagePanel = new ImagePanel<TEntity>(obj2);

        fieldInfo = Context.GetType().GetPropertyInfo<FieldInfoUIAttribute>();
        buttonsInfo = Context.GetType().GetPropertyInfo<ButtonInfoUIAttribute>();
    }

    public Form InitializeComponents(object? data)
    {
        return form
        .With(m => m.Controls.Clear())
        .With(m => m.Controls.Add(CreateUI()));
    }

    private Control? CreateUI()
    {
        Control ip = null;

        if (imagePanel != null)
            ip = imagePanel.Images();

        var fp = FieldsPanel(fieldInfo);
        var bp = ButtonsPanel(buttonsInfo);

        return FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsolute(fp, fp.PreferredSize.Height)
            .ControlAddIsRowsPercentV2(ip)
            .ControlAddIsRowsAbsolute(bp, bp.PreferredSize.Height);
    }

    private Control FieldsPanel(IEnumerable<FieldInfoUIAttribute> fieldsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t => fieldsInfo.ForEach(
                p => t.ControlAddIsRowsAbsolute(CreateField(p), p.Size + 1)))
            .ControlAddIsRowsPercentV2();

    private Control ButtonsPanel(IEnumerable<ButtonInfoUIAttribute> buttonsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                var enumerator = buttonsInfo.GetEnumerator();

                for (int i = 0; i < buttonsInfo.Count(); i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsolute(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (enumerator.MoveNext())

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercent(FactoryElements.Button(enumerator.Current, Context));
                }

                if (t.Controls[^1].Controls.Count < 4)
                    if (t.Controls[^1] is TableLayoutPanel table)
                        for (int i = table.Controls.Count; i < 4; i++)
                            table.ControlAddIsColumnPercent(FactoryElements.Button(""));
            });

    private Control CreateField(FieldInfoUIAttribute? fieldInfoAttribute)
        => FactoryElements.TableLayoutPanel()
            .With(t => t.Padding = new Padding(0))
            .StartNewRowTableAbsolute(fieldInfoAttribute.Size)
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, fieldInfoAttribute.Size))
                .ControlAddIsColumnPercentV2(FactoryElements.Label_11(fieldInfoAttribute.Text), 30)
                .ControlAddIsColumnPercentV2(FactoryElements.TextBox(fieldInfoAttribute.PlaceholderText)
                        .With(t => t.Multiline = fieldInfoAttribute.Multiline)
                        .With(t => t.ReadOnly = fieldInfoAttribute.ReadOnly)
                        .With(t => t.DataBindings.Add(nameof(t.Text), Context, fieldInfoAttribute.NameProperty, false, DataSourceUpdateMode.OnPropertyChanged))
                        .With(t => errorProviderView.OnErrorProvider(fieldInfoAttribute.NameProperty, t)), 70)
                .ControlAddIsColumnAbsolute(10);
}

