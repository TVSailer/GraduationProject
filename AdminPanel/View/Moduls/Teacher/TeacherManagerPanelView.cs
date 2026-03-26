using Admin.ViewModel.Model.Teacher;
using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Admin.View.Moduls.Teacher;

public class TeacherManagerPanelView(TeacherManagerPanelViewModel viewModel) : UiView<TeacherManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row()
                .Column(80).Content()
                    .CardFlowLayoutPanel<TeacherEntity, TeacherCard>(() => viewModel.Teachers)
                    .ClickedCard(viewModel.LoadDetailsPanel)
                    .Binding(viewModel)
                    .Initialize()
                .End()
                .Column(20).Content()
                    .Panel()
                    .Contents(build => build.Column()
                        .RowAbsolute(45)
                            .Column().Content()
                                .Label("Имя: ")
                            .End()
                            .Column().Content()
                                .TextBox()
                                .Binding(viewModel, nameof(viewModel.Name))
                            .End()
                        .End()
                        .RowAbsolute(45)
                            .Column().Content()
                                .Label("Фамилия: ")
                            .End()
                            .Column().Content()
                                .TextBox()
                                .Binding(viewModel, nameof(viewModel.Surname))
                            .End()
                        .End()
                        .Row()
                        .End()
                        .RowAbsolute(80).Content()
                            .Button("Очистить поиск")
                            .Command(viewModel.ClearSearch)
                        .End())  
                .End()
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.LoadAddingPanel)
                .End()
                .Column().Content()
                    .Button()
                .End()
                .Column().Content()
                    .Button()
                .End()
            .End()
        ;

}