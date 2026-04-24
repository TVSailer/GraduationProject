using Admin.ViewModel.Category;
using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.View;

namespace Admin.View.Category;

public class CategoryPanelView(CategoryPanelViewModel viewModel) : Forma<CategoryPanelViewModel>
{
    public override void Initialize()
    {
        Text = "Управление категориями";
        Size = new Size(600, 600);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.Column()
        .Row(10)
            .Column(22).Content()
                .Label("Название:")
            .End()
            .Column(48).Content()
                .TextBox("Введите название категории")
                .Binding(viewModel, nameof(viewModel.Category))
            .End()
            .Column(5)
            .End()
            .Column(25).Content()
                .Button("Добавить")
                .Command(viewModel.Add)
            .End()
        .End()
        .Row(80).Content()
            .CardTableLayoutPanel<CategoryEntity, CategoryCard>()
            .ContextMenu("Удалить", viewModel.Delete)
            .Binding(viewModel, nameof(viewModel.CategoryEntities))
        .End()
        .Row(10).Content()
            .Button("Назад")
            .Command(viewModel.Exit)
        .End()
    ;
}