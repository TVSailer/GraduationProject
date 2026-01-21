using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using Logica;
using System.Reflection;

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
            var fieldInfo = context.GetType().GetAttributes<FieldInfoUIAttribute>();

            if (context is PropertyChange obj1)
                errorProviderView = new ErrorProviderView(obj1);
            else throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

            if (fieldInfo != null)
                this.fieldInfo = fieldInfo;
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
                .ControlAddIsColumnPercent(FactoryElements.Label_11(fieldInfoAttribute.LabelText), 30)
                .ControlAddIsColumnPercent(fieldInfoAttribute.GetContol(context)
                    .With(t => errorProviderView.OnErrorProvider(fieldInfoAttribute.PropertyName, t)), 70)
                .ControlAddIsColumnAbsolute(10);
    }
}
