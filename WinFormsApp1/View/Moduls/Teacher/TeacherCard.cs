using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Teacher
{
    public class TeacherCard : ObjectCard<TeacherEntity>
    {
        public TeacherCard()
        {
            Size = new Size(900, 50);
            Margin = new Padding(1);
            Padding = new Padding(1);
        }

        public override ObjectCard<TeacherEntity> Initialize(TeacherEntity obj)
        {
            return base.Initialize(obj);
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsColumnPercent(
                    FactoryElements.Label_11($"{entity.ToString()}")
                    .With(l => l.ForeColor = Color.DarkBlue), 50)
                .ControlAddIsColumnPercent(
                    FactoryElements.Label_11($"📞 {entity.NumberPhone}")
                    .With(l => l.ForeColor = Color.Gray), 25)
                .ControlAddIsColumnPercent(
                    FactoryElements.Label_11($"🎨 Кружков: {0}")
                    .With(l => l.ForeColor = Color.DarkGreen), 25);
    }
}
