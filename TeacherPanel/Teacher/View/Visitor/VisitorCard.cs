using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Teacher.View.Visitor
{
    public class VisitorCard : ObjectCard<VisitorEntity>
    {
        public VisitorCard()
        {
            Size = new Size(480, 150);
        }

        public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
           => new BuilderLayoutPanel().Column()
               .Row(30).Content().Label($"{Entity}").ForeColor(Color.DarkBlue).Size(14).End()
               .Row(23).Content().Label($"🎂 {Entity.DateBirth}").ForeColor(Color.Gray).Size(12).End()
               .Row(23).Content().Label($"📞 {Entity.NumberPhone}").ForeColor(Color.Gray).Size(12).End()
               .Row(24).Content().Label($"🎯 {Entity.Lessons.Count}").ForeColor(Color.DarkGreen).Size(12).End();
    }
}
