using Admin.ViewModel.Model.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.ImagePanel;
using UserInterface.View;

namespace Admin.View.Moduls.Lesson;

public class LessonPanelUi<TButtons>(
    TeacherRepository teacherRepository,
    TButtons buttons,
    CategoryRepository eventCategoryRepository) : UiView<LessonFieldData, LessonEntity>
    where TButtons : IButtons<LessonFieldData>
{
    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.ObjectBinding(DataUi).CreateColumn()
            .Row()
                .Column()
                    .Row(SizeRow).LabelTextBox("Название: ", "Введите название", nameof(LessonFieldData.Name))
                    .Row(SizeRow).LabelTextBoxReadOnly("Расписание: ", "Создайте расписание", nameof(LessonFieldData.ScheduleParse))
                    .Row(SizeRow).LabelTextBox("Место проведения: ", "Введите место проведения", nameof(LessonFieldData.Location))
                    .Row(SizeRow).LabelNumeric("Кол. участников: ", nameof(LessonFieldData.MaxParticipants))
                    .Row(SizeRow).LabelComboBox("Категория: ", nameof(LessonFieldData.Category), eventCategoryRepository.Get())
                    .Row(SizeRow).LabelComboBox("Преподователь: ", nameof(LessonFieldData.Teacher), teacherRepository.Get())
                    .Row(80).LabelTextBoxMultiline("Описание: ", "Введите описание", nameof(LessonFieldData.Description))
                .End()
                .Column()
                    .RowAutoSize().Content().Label("📷 Изображения:").End()
                    .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
                .End()
            .End()
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel(buttons.GetButtons(DataUi)));
    }
}