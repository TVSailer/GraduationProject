using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Lesson
{
    public class LessonCard : ObjectCard<LessonEntity>
    {
        private double reting;

        public LessonCard(LessonEntity data)
            : base(data)
        {
            Size = new Size(400, 240);
            CreateContent();

            if (entity != null && entity.Reviews.Count > 0)
            {
                entity.Reviews.ForEach(r => reting += r.Rating);
                reting /= entity.Reviews.Count;
            }
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.Label_11(entity.Name)
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🏷️ {entity.Category}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👨‍🏫 {entity.Teacher.ToString()}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🕒 {entity.Schedule}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👥 {entity.Visitors.Count}/{entity.MaxParticipants}")
                .With(l => l.ForeColor = Color.DarkGreen), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"★ {reting}")
                .With(l => l.ForeColor = Color.Red), 30);
    }
}


