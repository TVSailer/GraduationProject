using Admin.View.ViewForm;
using Admin.ViewModel.Lesson;
using Logica;
using WinFormsApp1.View;
using Admin.View.ImagePanel;

namespace Admin.View.Moduls.Lesson
{
    public class LessonAddingView : LessonDataView
    {
        public LessonAddingView(AdminMainView mainView, LessonAddingViewModel modelView) : base(mainView, modelView)
        {
            form.Text = "➕ Добавление кружка";
        }

        public override Form InitializeComponents()
        {
            var buttonPanel = new ButtonPanel(
                new List<ButtonInfo>()
                {
                    new ButtonInfo("❌ Удалить изображение", nameof(context.OnDeletingImg)),
                    new ButtonInfo("➕ Добавить изображения", nameof(context.OnAddingImg)),
                    new ButtonInfo("💾 Сохранить", nameof(context.OnSave)),
                    new ButtonInfo("❌ Отмена", nameof(context.OnBack))
                }, context);

            int heinght = 54;

            var fieldsPanel = new FieldsPanel(
                new List<LessonFieldView>()
                {
                    new LessonFieldView("Название:*", "Введите название", nameof(context.Name), Field, heinght),
                    new LessonFieldView("Категория:*", "Введите категорию", nameof(context.Category), Field, heinght),
                    new LessonFieldView("Расписание:*", "Введите расписание, например: Пн, Ср, Пт 19:00-20:30", nameof(context.Schedule), Field, heinght),
                    new LessonFieldView("Место проведения:*", "Введите место проведения", nameof(context.Location), Field, heinght),
                    new LessonFieldView("Кол. участников:*", "", nameof(context.MaxParticipants), Field, heinght),
                    new LessonFieldView("Преподователь:*", "Выберите преподователя",  nameof(context.Teacher), FieldTeacher, heinght),
                    new LessonFieldView("Описание:*", "Введите описание мероприятия", nameof(context.Description), FieldsDescription, 100),
                });

            var imagePanel = new ImagPanel(context);

            var view = new ViewFormWithImgs(form, buttonPanel, fieldsPanel, imagePanel);

            return view.InitializeComponents();
        }
    }
}
