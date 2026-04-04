using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.Moduls.Visitor
{
    public class VisitorCard : ObjectCard<VisitorEntity>
    {
        public VisitorCard()
        {
            Size = new Size(400, 120);
        }

        public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
           => new BuilderLayoutPanel().Column()
               .Row(30).Content().Label($"{Entity}").ForeColor(Color.DarkBlue).End()
               .Row(23).Content().Label($"🎂 {Entity.DateBirth}").ForeColor(Color.Gray).End()
               .Row(23).Content().Label($"📞 {Entity.NumberPhone}").ForeColor(Color.Gray).End()
               .Row(24).Content().Label($"🎯 {Entity.Lessons.Count}").ForeColor(Color.DarkGreen).End();
    }
}
