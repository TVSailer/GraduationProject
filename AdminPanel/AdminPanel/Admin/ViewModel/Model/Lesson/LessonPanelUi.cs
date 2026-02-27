using Admin.View.UIModeles;
using Admin.ViewModel.GenericEntity;
using Admin.ViewModel.Model.Lesson.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.TableLayerPanel.Extension;
using User_Interface_Library.UiLayoutPanel;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.UiLayoutPanel.ImagePanel;
using User_Interface_Library.View;

namespace Admin.ViewModel.Model.Lesson;

public class LessonPanelUi<TButtons>(
    TeacherRepository teacherRepository,
    LessonFieldData lessonField,
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<LessonFieldData, LessonEntity>
    where TButtons : IButtons<LessonFieldData>
{
    public const int SizeRow = 5;

    protected override Control? CreateUi()
    {
        return LayoutPanel.CreateColumn().ObjectBinding(lessonField)
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
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(lessonField)))
            .Build();
    }
}