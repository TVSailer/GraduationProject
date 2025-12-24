using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Lesson
{
    public class LessonCard : ObjectCard
    {
        private readonly LessonEntity lesson;

        public LessonCard(LessonEntity lessonEn)
            : base()
        {
            Size = new Size(400, 240);
            lesson = lessonEn;
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.Label_11(lesson.Name)
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🏷️ {lesson.Category}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👨‍🏫 {lesson.Teacher.ToString()}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🕒 {lesson.Schedule}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👥 {lesson.CurrentParticipants}/{lesson.MaxParticipants}")
                .With(l => l.ForeColor = Color.DarkGreen), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"★ {lesson.Rating}")
                .With(l => l.ForeColor = Color.Red), 30);
    }
}


