using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson;

public class LessonPanelUi<TButtons>(
    TeacherRepository teacherRepository,
    LessonFieldData lessonField,
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<LessonFieldData, LessonEntity>(lessonField)
    where TButtons : IButtons<LessonFieldData>
{
    public const int SizeRow = 5;

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.CreateColumn().ObjectBinding(lessonField)
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(lessonField.Name))
                    .Row(SizeRow).LabelTextBoxReadOnly("Расписание: ", "Создайте расписание", nameof(lessonField.ScheduleParse))
                    .Row(SizeRow).LabelTextBox("Место проведения: ", "Введите место проведения", nameof(lessonField.Location))
                    .Row(SizeRow).LabelNumeric("Кол. участников: ", nameof(lessonField.MaxParticipants))
                    .Row(SizeRow).LabelComboBox("Категория: ", nameof(lessonField.Category), eventCategoryRepository.Get())
                    .Row(SizeRow).LabelComboBox("Преподователь: ", nameof(lessonField.Teacher), teacherRepository.Get())
                    .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(lessonField.Description))
                .End()
                .Column()
                    .RowAutoSize().Content().Label("📷 Изображения:").End()
                    .Row().ContentEnd(new ImageLayoutPanel(lessonField.RepositoryImgEntity))
                .End()
            .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(lessonField)));
    }
}