using Admin.View.Moduls.Event;
using Admin.View.ViewForm;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using WinFormsApp1.View;

public class UI<TEntity> : IView
    where TEntity : Entity
{
    protected readonly AdminMainView form;
    protected IViewModel<TEntity> context;
    protected ErrorProviderView errorProviderView;
    protected ImagePanel<TEntity> imagePanel;

    public UI(AdminMainView mainView)
    {
        this.form = mainView;
    }

    public Form InitializeComponents(object? data)
    {
        if (data is IViewModel<TEntity> context)
        {
            this.context = context;

            if (context is PropertyChange obj1)
                errorProviderView = new ErrorProviderView(obj1);
            else throw new ArgumentException("Переданный ViewModel не наследует класс PropertyChange");

            if (context is ViewModelWithImages<TEntity> obj2)
                imagePanel = new ImagePanel<TEntity>(obj2);
        }
        else throw new ArgumentException();

        return form
        .With(m => m.Controls.Clear())
        .With(m => m.Controls.Add(CreateUI()));
    }

    private Control? CreateUI()
    {
        var descrip = context.GetDescription();

        var tp = FieldsPanel(descrip.fieldsInfo);
        var ip = imagePanel.Images();
        var bp = ButtonsPanel(descrip.buttonsInfo);

        return FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(tp, tp.PreferredSize.Height)
            .ControlAddIsRowsPercentV2(ip)
            .ControlAddIsRowsAbsoluteV2(bp, bp.PreferredSize.Height);
    }

    private Control FieldsPanel(List<FieldInfoAttribute> fieldsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t => fieldsInfo.ForEach(
                p => t.ControlAddIsRowsAbsoluteV2(CreateField(p), p.Size + 1)))
            .ControlAddIsRowsPercentV2();

    private Control ButtonsPanel(List<ButtonInfoAttribute> buttonsInfo)
        => FactoryElements.TableLayoutPanel()
            .With(t =>
            {
                for (int i = 0; i < buttonsInfo.Count; i++)
                {
                    if (i % 4 == 0 || i == 0)
                        t.ControlAddIsRowsAbsoluteV2(new TableLayoutPanel() { Dock = DockStyle.Fill }, 70);

                    if (t.Controls[^1] is TableLayoutPanel table)
                        table.ControlAddIsColumnPercentV2(FactoryElements.Button(buttonsInfo[i], context));
                }

                if (t.Controls[^1].Controls.Count < 4)
                    if (t.Controls[^1] is TableLayoutPanel table)
                        for (int i = table.Controls.Count; i < 4; i++)
                            table.ControlAddIsColumnPercentV2(FactoryElements.Button(""));
            });

    private Control CreateField(FieldInfoAttribute? fieldInfoAttribute)
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

