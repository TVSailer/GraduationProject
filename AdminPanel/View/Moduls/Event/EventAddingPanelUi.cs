using System.Windows.Input;
using Abstract.View;
using AbstractView.View;
using Admin.FieldData.Model.Event;
using Domain.Command;
using Domain.Entitys;
using Domain.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;

namespace Admin.View.Moduls.Event;

public class EventAddingPanelView(EventViewModel viewModel, ControlView controlView, IRepository<CategoryEntity> repositoryC) : UiView
{
    private readonly ICommand _exit = new ExecuteCommand(_ => controlView.Exit());

    const int SizeRow = 5;
    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
    {
        return layout.Column()
            .Row()
                .Column()
                    .Row(SizeRow)
                        .Column(10).Content()
                            .Label("Название: ")
                            .End()
                        .Column(40).Content()
                            .TextBox("Введите название")
                            .Binding(viewModel, nameof(viewModel.Title)).End()
                        .Column(30, SizeType.Absolute).End()
                    .End()
                    //.Row(SizeRow).LabelDatePicker("Дата:", "dd.MM.yyyy", nameof(EventFieldData.Date))
                    //.Row(SizeRow).LabelDatePicker("Начало:", "HH:mm", nameof(EventFieldData.Start))
                    //.Row(SizeRow).LabelDatePicker("Конец", "HH:mm", nameof(EventFieldData.End))
                    //.Row(SizeRow).LabelComboBox("Категория: ", nameof(EventFieldData.Category), eventCategoryRepository.Get())
                    //.Row(SizeRow).LabelTextBox("Место: ", "Введите место проведения", nameof(EventFieldData.Location))
                    //.Row(SizeRow).LabelTextBox("Ссылка на регистрацию: ", "Введите ссылку на регистрацию", nameof(EventFieldData.RegisLink))
                    //.Row(SizeRow).LabelTextBox("Организатор: ", "Введите фио организатора", nameof(EventFieldData.Organizer))
                    .Row(80)
                        .Column(10).Content()
                            .Label("Описание: ")
                        .End()
                        .Column(40).Content()
                            .TextBox("Введите описание")
                            .Binding(viewModel, nameof(viewModel.Description))
                            .Multiline()
                        .End()
                        .Column(30, SizeType.Absolute).End()
                    .End()
                .End()
            //.Column()
            //    .RowAutoSize().Content().Label("📷 Изображения:").End()
            //    .Row().ContentEnd(new ImageLayoutPanel(DataUi.RepositoryImgEntity))
            //.End()
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(_exit)
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.Save)
                .End()
            .End();
    }
}