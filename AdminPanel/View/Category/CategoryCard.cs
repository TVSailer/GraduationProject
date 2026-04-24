using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Admin.View.Category;

public class CategoryCard : ObjectCard<CategoryEntity>
{
    public CategoryCard()
    {
        Height = 35;
        Dock = DockStyle.Top;
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize()
                .Column().Content()
                    .Label($"{Entity.Id}. {Entity.Category} ")
                    .Alignment(ContentAlignment.MiddleLeft)
                .End();
}