using DataAccess.Postgres.Models;
using Logica;

namespace WinFormsApp1.View.Teachers
{
    public class TeacherCard : ObjectCard
    {
        private readonly TeacherEntity teacher;

        public TeacherCard(TeacherEntity teacherEntity)
            : base(teacherEntity.Id)
        {
            Size = new Size(800, 50);
            Margin = new Padding(1);
            Padding = new Padding(1);
            teacher = teacherEntity;
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsColumnPercentV2(
                    FactoryElements.Label_11($"{teacher.Surname} {teacher.Name} {teacher.Patronymic}")
                    .With(l => l.ForeColor = Color.DarkBlue), 50)
                .ControlAddIsColumnPercentV2(
                    FactoryElements.Label_09($"📞 {teacher.NumberPhone}")
                    .With(l => l.ForeColor = Color.Gray), 25)
                .ControlAddIsColumnPercentV2(
                    FactoryElements.Label_09($"🎨 Кружков: {0}")
                    .With(l => l.ForeColor = Color.DarkGreen), 25);
    }
}
