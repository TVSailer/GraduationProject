using DataAccess.PostgreSQL.Models;
using ExtensionFunc;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    public LessonCard()
    {
        Size = new Size(300, 125);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().ContentEnd(FactoryElements.Label_11(Entity.Name).With(l => l.ForeColor = Color.DarkBlue))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"🏷️ {Entity.Category}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"👨‍🏫 {Entity.Teacher}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"👥 {Entity.Visitors.Count}/{Entity.MaxParticipants}").With(l => l.ForeColor = Color.DarkGreen))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"★ {Entity.Rating()}").With(l => l.ForeColor = Color.Red))
            .Build();
}