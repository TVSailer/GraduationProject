using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica;
using Logica.Extension;

namespace Admin.View.Moduls.UIModel
{
    public class FieldEntityModule : IUIModel
    {
        private readonly PropertyChange context;
        private readonly List<FieldInfoUiAttribute> fieldInfo = new();

        public FieldEntityModule(IViewModele context)
        {
            fieldInfo = context.GetType().GetAttributes<FieldInfoUiAttribute>();

            if (context is not PropertyChange pc)
                throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

            this.context = pc;
        }

        public Control CreateControl()
        => FactoryElements.TableLayoutPanel()
            .With(t => fieldInfo.ForEach(
                p => t.ControlAddIsRowsAbsolute(CreateField(p), p.Size + 1)))
            .ControlAddIsRowsPercent();

        private Control CreateField(FieldInfoUiAttribute? fieldInfoAttribute)
            => FactoryElements.TableLayoutPanel()
            .With(t => t.Padding = new Padding(0))
            .StartNewRowTableAbsolute(fieldInfoAttribute.Size)
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, fieldInfoAttribute.Size))
                .ControlAddIsColumnPercent(FactoryElements.Label_11(fieldInfoAttribute.LabelText), 30)
                .ControlAddIsColumnPercent(fieldInfoAttribute
                    .GetContol(context)
                    .OnErrorProvider(fieldInfoAttribute.PropertyName, context), 70)
                .ControlAddIsColumnAbsolute(10);
    }
}
