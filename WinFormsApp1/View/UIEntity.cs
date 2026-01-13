using Admin.View.Moduls.Event;
using Admin.View.ViewForm;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

public class UIEntity<TEntity> : IView
    where TEntity : Entity, new()
{
    protected readonly AdminMainView form;
    protected ErrorProviderView errorProviderView;
    protected ImagePanel<TEntity> imagePanel;

    protected List<IViewModele<TEntity>> context = new();
    protected List<FieldInfoUIAttribute> fieldInfo = new();
    protected List<ButtonInfoUIAttribute> buttonsInfo = new();
    protected ICommand command;

    public UIEntity(AdminMainView mainView, params IViewModele<TEntity>[] viewModels)
    {
        form = mainView;

        viewModels
            .ToList()
            .ForEach(v => {

                if (context is PropertyChange obj1)
                    errorProviderView = new ErrorProviderView(obj1);
                else throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

                if (context is IViewModeleWithImgs<TEntity> obj2)
                    imagePanel = new ImagePanel<TEntity>(obj2);
        });


        fieldInfo = context.GetPropertyInfo<FieldInfoUIAttribute>();
        buttonsInfo = context.GetPropertyInfo<ButtonInfoUIAttribute>();
    }

    public Form InitializeComponents(object? data)
    {
        return form
        .With(m => m.Controls.Clear())
        .With(m => m.Controls.Add(CreateUI()));
    }

    private Control? CreateUI()
    {
        var listF = fieldInfo
            .Where(f => f.LinkCommand.Equals(command));
        var listB = buttonsInfo
            .Where(b => b.LinkCommand.Equals(command));

        Control ip = null;

        if (imagePanel != null)
            ip = imagePanel.Images();

        var fp = FieldsPanel(listF);
        var bp = ButtonsPanel(listB);

        return FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(fp, fp.PreferredSize.Height)
            .ControlAddIsRowsPercentV2(ip)
            .ControlAddIsRowsAbsoluteV2(bp, bp.PreferredSize.Height);
    }

    private Control FieldsPanel(IEnumerable<FieldInfoUIAttribute> fieldsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t => fieldsInfo.ForEach(
                p => t.ControlAddIsRowsAbsoluteV2(CreateField(p), p.Size + 1)))
            .ControlAddIsRowsPercentV2();

    private Control ButtonsPanel(IEnumerable<ButtonInfoUIAttribute> buttonsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                var enumerator = buttonsInfo.GetEnumerator();

                for (int i = 0; i < buttonsInfo.Count(); i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsoluteV2(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (enumerator.MoveNext())

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercentV2(FactoryElements.Button(enumerator.Current, context));
                }

                if (t.Controls[^1].Controls.Count < 4)
                    if (t.Controls[^1] is TableLayoutPanel table)
                        for (int i = table.Controls.Count; i < 4; i++)
                            table.ControlAddIsColumnPercentV2(FactoryElements.Button(""));
            });

    private Control CreateField(FieldInfoUIAttribute? fieldInfoAttribute)
        => FactoryElements.TableLayoutPanel()
            .With(t => t.Padding = new Padding(0))
            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, fieldInfoAttribute.Size))
                .ControlAddIsColumnPercentV2(FactoryElements.Label_11(fieldInfoAttribute.Text), 30)
                .ControlAddIsColumnPercentV2(FactoryElements.TextBox(fieldInfoAttribute.PlaceholderText)
                        .With(t => t.Multiline = fieldInfoAttribute.Multiline)
                        .With(t => t.ReadOnly = fieldInfoAttribute.ReadOnly)
                        .With(t => t.DataBindings.Add(nameof(t.Text), context, fieldInfoAttribute.NameProperty, false, DataSourceUpdateMode.OnPropertyChanged))
                        .With(t => errorProviderView.OnErrorProvider(fieldInfoAttribute.NameProperty, t)), 70)
                .ControlAddIsColumnAbsoluteV2(10), fieldInfoAttribute.Size);
}

