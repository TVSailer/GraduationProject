using DataAccess.Postgres.Models;
using DataAccess.Postgres.Models.Imgs;

using Microsoft.EntityFrameworkCore;
using Day = DataAccess.Postgres.Enum.Day;

namespace DataAccess.Postgres.Seeding
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Очистка существующих данных (опционально)
            await ClearDatabaseAsync(context);

            // Создание данных в правильном порядке (учитывая зависимости)
            var categories = CreateCategories();
            await context.Category.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var auths = CreateAuths();
            await context.Auths.AddRangeAsync(auths);
            await context.SaveChangesAsync();

            var teachers = CreateTeachers(auths);
            await context.Teachers.AddRangeAsync(teachers);
            await context.SaveChangesAsync();

            var visitors = CreateVisitors(auths.Skip(5).ToList());
            await context.Visitors.AddRangeAsync(visitors);
            await context.SaveChangesAsync();

            var lessons = CreateLessons(categories, teachers);
            await context.Lessons.AddRangeAsync(lessons);
            await context.SaveChangesAsync();

            var lessonSchedules = CreateLessonSchedules(lessons);
            await context.LessonSchedule.AddRangeAsync(lessonSchedules);
            await context.SaveChangesAsync();

            var dateAttendances = CreateDateAttendances(lessons);
            await context.DateAttendances.AddRangeAsync(dateAttendances);
            await context.SaveChangesAsync();

            var news = CreateNews(categories);
            await context.News.AddRangeAsync(news);
            await context.SaveChangesAsync();

            var events = CreateEvents(categories);
            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();

            var reviews = CreateReviews(visitors, lessons);
            await context.Reviews.AddRangeAsync(reviews);
            await context.SaveChangesAsync();

            var imgLessons = CreateImgLessons(lessons);
            await context.ImagesLesson.AddRangeAsync(imgLessons);
            await context.SaveChangesAsync();

            var imgNews = CreateImgNews(news);
            await context.ImagesNews.AddRangeAsync(imgNews);
            await context.SaveChangesAsync();

            var imgEvents = CreateImgEvents(events);
            await context.ImagesEvent.AddRangeAsync(imgEvents);
            await context.SaveChangesAsync();
        }

        private static async Task ClearDatabaseAsync(ApplicationDbContext context)
        {
            // Удаление в обратном порядке зависимостей
            context.ImagesEvent.RemoveRange(await context.ImagesEvent.ToListAsync());
            context.ImagesNews.RemoveRange(await context.ImagesNews.ToListAsync());
            context.ImagesLesson.RemoveRange(await context.ImagesLesson.ToListAsync());
            context.Reviews.RemoveRange(await context.Reviews.ToListAsync());
            context.DateAttendances.RemoveRange(await context.DateAttendances.ToListAsync());
            context.LessonSchedule.RemoveRange(await context.LessonSchedule.ToListAsync());
            context.Events.RemoveRange(await context.Events.ToListAsync());
            context.News.RemoveRange(await context.News.ToListAsync());
            context.Lessons.RemoveRange(await context.Lessons.ToListAsync());
            context.Visitors.RemoveRange(await context.Visitors.ToListAsync());
            context.Teachers.RemoveRange(await context.Teachers.ToListAsync());
            context.Auths.RemoveRange(await context.Auths.ToListAsync());
            context.Category.RemoveRange(await context.Category.ToListAsync());

            await context.SaveChangesAsync();
        }

        private static List<CategoryEntity> CreateCategories()
        {
            var categories = new List<CategoryEntity>();
            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new CategoryEntity($"Категория {i}"));
            }
            return categories;
        }

        private static List<AuthEntity> CreateAuths()
        {
            var auths = new List<AuthEntity>();
            for (int i = 1; i <= 10; i++)
            {
                auths.Add(new AuthEntity
                {
                    Login = $"user{i}@example.com",
                    Password = $"password{i}_hashed"
                });
            }
            return auths;
        }

        private static List<TeacherEntity> CreateTeachers(List<AuthEntity> auths)
        {
            var teachers = new List<TeacherEntity>();
            for (int i = 0; i < 5; i++)
            {
                teachers.Add(new TeacherEntity
                {
                    FIO = new FIO($"Иванов Иван Иванович{i + 1}"),
                    DateBirth = $"0{i + 1}/01/1980",
                    NumberPhone = $"+7(999)123-45-6{i}",
                    AuthId = auths[i].Id,
                    AuthEntity = auths[i]
                });
            }
            return teachers;
        }

        private static List<VisitorEntity> CreateVisitors(List<AuthEntity> auths)
        {
            var visitors = new List<VisitorEntity>();
            string[] names = { "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов" };
            string[] firstNames = { "Петр", "Сидор", "Алексей", "Дмитрий", "Михаил" };

            for (int i = 0; i < 5; i++)
            {
                visitors.Add(new VisitorEntity
                {
                    FIO = new FIO($"{names[i]} {firstNames[i]} {names[i]}ович"),
                    DateBirth = $"1{i}/05/1990",
                    NumberPhone = $"+7(999)987-65-4{i}",
                    AuthId = auths[i].Id,
                    AuthEntity = auths[i]
                });
            }
            return visitors;
        }

        private static List<LessonEntity> CreateLessons(List<CategoryEntity> categories, List<TeacherEntity> teachers)
        {
            var lessons = new List<LessonEntity>();
            string[] lessonNames = { "Йога", "Пилатес", "Зумба", "Кроссфит", "Стретчинг",
                                     "Бокс", "Танцы", "Плавание", "Бег", "Силовая" };

            for (int i = 0; i < 10; i++)
            {
                lessons.Add(new LessonEntity
                {
                    Name = lessonNames[i],
                    Description = $"Описание занятия {lessonNames[i]}",
                    Location = $"Зал {i + 1}",
                    MaxParticipants = 10 + i * 2,
                    CategoryId = categories[i % 5].Id,
                    Category = categories[i % 5],
                    TeacherId = teachers[i % 3].Id,
                    Teacher = teachers[i % 3]
                });
            }
            return lessons;
        }

        private static List<LessonScheduleEntity> CreateLessonSchedules(List<LessonEntity> lessons)
        {
            var schedules = new List<LessonScheduleEntity>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                schedules.Add(new LessonScheduleEntity(
                    new TimeOnly(10 + i, 0),
                    new TimeOnly(11 + i, 0),
                    (Day)(i % 7)
                )
                {
                    LessonId = lessons[i].Id,
                    Lesson = lessons[i]
                });
            }
            return schedules;
        }

        private static List<DateAttendanceEntity> CreateDateAttendances(List<LessonEntity> lessons)
        {
            var dates = new List<DateAttendanceEntity>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                dates.Add(new DateAttendanceEntity
                {
                    Date = DateTime.Now.AddDays(i).ToString("dd/MM/yyyy"),
                    LessonId = lessons[i % 5].Id,
                    Lesson = lessons[i % 5]
                });
            }
            return dates;
        }

        private static List<NewsEntity> CreateNews(List<CategoryEntity> categories)
        {
            var news = new List<NewsEntity>();
            string[] titles = {
                "Открытие нового зала",
                "Летний интенсив",
                "Новый тренер в команде",
                "Скидки на абонементы",
                "Соревнования по йоге",
                "Мастер-класс по пилатесу",
                "День открытых дверей",
                "Новое расписание",
                "Подарочные сертификаты",
                "Итоги месяца"
            };

            for (int i = 0; i < 10; i++)
            {
                news.Add(new NewsEntity
                {
                    Title = titles[i],
                    Content = $"Содержание новости: {titles[i]}. Здесь находится подробное описание события...",
                    Date = DateTime.Now.AddDays(-i).ToString("dd/MM/yyyy"),
                    CategoryId = categories[i % 5].Id,
                    Category = categories[i % 5],
                    Author = $"Администратор {i + 1}"
                });
            }
            return news;
        }

        private static List<EventEntity> CreateEvents(List<CategoryEntity> categories)
        {
            var events = new List<EventEntity>();
            string[] titles = {
                "Фестиваль йоги",
                "Марафон",
                "Турнир по кроссфиту",
                "Вечеринка в стиле зумба",
                "Семинар по питанию",
                "Детский праздник",
                "Спортивный выходной",
                "Лекция о здоровье",
                "Показательные выступления",
                "Новогодняя тренировка"
            };

            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventEntity
                {
                    Title = titles[i],
                    Description = $"Описание мероприятия: {titles[i]}",
                    Schedule = new EventScheduleEntity(
                        new TimeOnly(12 + i, 0),
                        new TimeOnly(14 + i, 0),
                        DateOnly.FromDateTime(DateTime.Now.AddDays(7 + i))
                    ),
                    Location = $"Конференц-зал {i + 1}",
                    CategoryId = categories[i % 5].Id,
                    Category = categories[i % 5],
                    RegistrationLink = $"https://example.com/event/{i + 1}",
                    Organizer = $"Организатор {i + 1}",
                    MaxParticipants = 50 + i * 5,
                    CurrentParticipants = 10 + i * 3
                });
            }
            return events;
        }

        private static List<ReviewEntity> CreateReviews(List<VisitorEntity> visitors, List<LessonEntity> lessons)
        {
            var reviews = new List<ReviewEntity>();
            string[] comments = {
                "Отличное занятие!",
                "Очень понравилось",
                "Хороший тренер",
                "Буду ходить еще",
                "Рекомендую",
                "Нормально",
                "Супер!",
                "Интересно",
                "Познавательно",
                "Класс!"
            };
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                reviews.Add(new ReviewEntity
                {
                    Date = DateTime.Now.AddDays(-random.Next(1, 30)).ToString("dd/MM/yyyy"),
                    Rating = random.Next(3, 6),
                    Comment = comments[i],
                    Visitor = visitors[i % 5],
                    Lesson = lessons[i % 5]
                });
            }
            return reviews;
        }

        private static List<ImgLessonEntity> CreateImgLessons(List<LessonEntity> lessons)
        {
            var imgs = new List<ImgLessonEntity>();
            for (int i = 0; i < 10; i++)
            {
                imgs.Add(new ImgLessonEntity($"https://example.com/lessons/lesson{i + 1}.jpg")
                {
                    LessonId = lessons[i % 5].Id,
                    Lesson = lessons[i % 5]
                });
            }
            return imgs;
        }

        private static List<ImgNewsEntity> CreateImgNews(List<NewsEntity> news)
        {
            var imgs = new List<ImgNewsEntity>();
            for (int i = 0; i < 10; i++)
            {
                imgs.Add(new ImgNewsEntity($"https://example.com/news/news{i + 1}.jpg")
                {
                    NewsId = news[i % 5].Id,
                    News = news[i % 5]
                });
            }
            return imgs;
        }

        private static List<ImgEventEntity> CreateImgEvents(List<EventEntity> events)
        {
            var imgs = new List<ImgEventEntity>();
            for (int i = 0; i < 10; i++)
            {
                imgs.Add(new ImgEventEntity($"https://example.com/events/event{i + 1}.jpg")
                {
                    EventId = events[i % 5].Id,
                    Event = events[i % 5]
                });
            }
            return imgs;
        }
    }
}