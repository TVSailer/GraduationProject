using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using Logica;

namespace Admin.View.Moduls.UIModel
{
    public class FieldEntityModule : IUIModel
    {
        private readonly ErrorProviderView errorProviderView;
        private readonly IViewModele context;
        private readonly List<FieldInfoUIAttribute> fieldInfo = new();

        public FieldEntityModule(IViewModele context)
        {
            this.context = context;
            var buttonsInfo = context.GetType().GetAttributes<FieldInfoUIAttribute>();

            if (context is PropertyChange obj1)
                errorProviderView = new ErrorProviderView(obj1);
            else throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

            if (buttonsInfo != null)
                this.fieldInfo = buttonsInfo;
        }

        public Control CreateControl()
        => FactoryElements.TableLayoutPanel()
            .With(t => fieldInfo.ForEach(
                p => t.ControlAddIsRowsAbsolute(CreateField(p), p.Size + 1)))
            .ControlAddIsRowsPercent();

        private Control CreateField(FieldInfoUIAttribute? fieldInfoAttribute)
        => FactoryElements.TableLayoutPanel()
            .With(t => t.Padding = new Padding(0))
            .StartNewRowTableAbsolute(fieldInfoAttribute.Size)
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, fieldInfoAttribute.Size))
                .ControlAddIsColumnPercent(FactoryElements.Label_11(fieldInfoAttribute.Text), 30)
                .ControlAddIsColumnPercent(FactoryElements.TextBox(fieldInfoAttribute.PlaceholderText)
                        .With(t => t.Multiline = fieldInfoAttribute.Multiline)
                        .With(t => t.ReadOnly = fieldInfoAttribute.ReadOnly)
                        .With(t => t.DataBindings.Add(nameof(t.Text), context, fieldInfoAttribute.NameProperty, false, DataSourceUpdateMode.OnPropertyChanged))
                        .With(t => errorProviderView.OnErrorProvider(fieldInfoAttribute.NameProperty, t)), 70)
                .ControlAddIsColumnAbsolute(10);
    }
}
