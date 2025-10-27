using DataAccess.Postgres.Models;

public partial class ViewVisitor
{
    private void LoadTestClubs()
    {
        clubs = new List<LessonEntity>
        {
            new LessonEntity
            {
                Name = "Программирование на Python",
                Description = "Изучаем основы программирования на языке Python. Создаем проекты, решаем задачи и готовимся к олимпиадам.",
                Category = "IT",
                Schedule = "Пн, Ср 16:00-18:00",
                Location = "Каб. 301",
                MaxParticipants = 20,
                CurrentParticipants = 15,
                Rating = 4.7,
                ReviewCount = 12,
                Reviews = new List<ReviewEntity>
                {
                }
            },
        };

        DisplayItems(clubs.ToArray(), CreateClubCard);
    } 
}
