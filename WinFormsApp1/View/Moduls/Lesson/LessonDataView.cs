using Admin.View.ImagePanel;
using Admin.View.ViewForm;
using Admin.ViewModel.Lesson;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Lesson
{
    public abstract class LessonDataView : ErrorProviderView, IViewForm
    {
        protected int heightNeverBlink = 10;
        protected readonly AdminMainView form;
        protected readonly LessonDataViewModel context;

        public LessonDataView(AdminMainView mainView, LessonDataViewModel modelView) : base(modelView)
        {
            context = modelView;
            form = mainView;
        }

        protected TableLayoutPanel FieldsDescription(string textLabel, string placeholderText, string attribute)
        {
            return FactoryElements.TableLayoutPanel()
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, 90))
                .ControlAddIsColumnPercentV2(FactoryElements.Label_11(textLabel), 30)
                .ControlAddIsColumnPercentV2(FactoryElements.TextBoxMultiline(placeholderText)
                    .With(t => t.DataBindings.Add(nameof(t.Text), context, attribute, false, DataSourceUpdateMode.OnPropertyChanged))
                    .With(t => OnErrorProvider(attribute, t)), 70)
                .ControlAddIsColumnAbsoluteV2(heightNeverBlink);
        }

        protected TableLayoutPanel FieldTeacher(string textLabel, string placeholderText, string attribute)
        {
            return FactoryElements.TableLayoutPanel()
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, 42))
                .ControlAddIsColumnPercentV2(FactoryElements.Label_11(textLabel), 30)
                .ControlAddIsColumnPercentV2(FactoryElements.TextBox(placeholderText)
                    .With(t => t.DataBindings.Add(nameof(t.Text), context, attribute, false, DataSourceUpdateMode.OnPropertyChanged))
                    .With(t => t.ReadOnly = true), 60)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("Выбрать", context, nameof(context.OnBindingTeacher))
                    .With(t => t.BackColor = SystemColors.ButtonFace)
                    .With(t => OnErrorProvider(attribute, t)), 10)
                .ControlAddIsColumnAbsoluteV2(heightNeverBlink);
        }

        protected TableLayoutPanel Field(string textLabel, string placeholderText, string attribute)
        {
            return FactoryElements.TableLayoutPanel()
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, 42))
                .ControlAddIsColumnPercentV2(FactoryElements.Label_11(textLabel), 30)
                .ControlAddIsColumnPercentV2(FactoryElements.TextBox(placeholderText)
                    .With(t => t.DataBindings.Add(nameof(t.Text), context, attribute, false, DataSourceUpdateMode.OnPropertyChanged))
                    .With(t => OnErrorProvider(attribute, t)), 70)
                .ControlAddIsColumnAbsoluteV2(heightNeverBlink);
        }

        public abstract Form InitializeComponents();
    }
}
