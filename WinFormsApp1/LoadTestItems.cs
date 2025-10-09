public partial class ViewVisitor : Form
{
    private void LoadTestClubs()
    {
        clubs = new List<Club>
    {
        new Club
        {
            Name = "Программирование на Python",
            Description = "Изучаем основы программирования на языке Python. Создаем проекты, решаем задачи и готовимся к олимпиадам.",
            Category = "IT",
            Leader = "Иванов А.С.",
            Schedule = "Пн, Ср 16:00-18:00",
            Location = "Каб. 301",
            MaxParticipants = 20,
            CurrentParticipants = 15,
            Rating = 4.7,
            ReviewCount = 12,
            Reviews = new List<Review>
            {
                new Review { Author = "Мария", Date = DateTime.Now.AddDays(-5), Rating = 5, Comment = "Отличный кружок! Преподаватель очень понятно объясняет." },
                new Review { Author = "Алексей", Date = DateTime.Now.AddDays(-10), Rating = 4, Comment = "Хорошая программа, но хотелось бы больше практики" }
            }
        },
        new Club
        {
            Name = "Робототехника",
            Description = "Собираем и программируем роботов. Участвуем в соревнованиях и создаем собственные проекты.",
            Category = "Техника",
            Leader = "Петров В.И.",
            Schedule = "Вт, Чт 15:00-17:00",
            Location = "Лаборатория робототехники",
            MaxParticipants = 15,
            CurrentParticipants = 12,
            Rating = 4.9,
            ReviewCount = 8,
            Reviews = new List<Review>
            {
                new Review { Author = "Дмитрий", Date = DateTime.Now.AddDays(-3), Rating = 5, Comment = "Супер! Собрал своего первого робота!" }
            }
        },
        new Club
        {
            Name = "Шахматный клуб",
            Description = "Учимся играть в шахматы, участвуем в турнирах, разбираем интересные партии.",
            Category = "Интеллектуальные игры",
            Leader = "Сидоров П.К.",
            Schedule = "Пн, Пт 17:00-19:00",
            Location = "Каб. 215",
            MaxParticipants = 25,
            CurrentParticipants = 18,
            Rating = 4.5,
            ReviewCount = 15,
            Reviews = new List<Review>
            {
                new Review { Author = "Ольга", Date = DateTime.Now.AddDays(-7), Rating = 4, Comment = "Хороший клуб, но мало времени на практику" },
                new Review { Author = "Сергей", Date = DateTime.Now.AddDays(-15), Rating = 5, Comment = "Отличный преподаватель! Научился думать на несколько ходов вперед" }
            }
        },
        new Club
        {
            Name = "Фотография",
            Description = "Осваиваем искусство фотографии. Учимся работать с техникой, светом и композицией.",
            Category = "Творчество",
            Leader = "Козлова Е.В.",
            Schedule = "Ср, Сб 14:00-16:00",
            Location = "Фотостудия",
            MaxParticipants = 12,
            CurrentParticipants = 10,
            Rating = 4.8,
            ReviewCount = 6,
            Reviews = new List<Review>
            {
                new Review { Author = "Анна", Date = DateTime.Now.AddDays(-2), Rating = 5, Comment = "Потрясающие занятия! Уже сделала первые профессиональные снимки" }
            }
        }
    };

        DisplayItems(clubs.ToArray(), CreateClubCard);
    }

    private void LoadTestNews()
    {
        // Тестовые данные новостей
        allNews = new List<NewsItem>
        {
            new NewsItem
            {
                Title = "Запуск новой версии системы",
                Content = "Мы рады сообщить о запуске обновленной версии платформы. Добавлены новые функции и улучшена производительность.",
                Author = "Администратор",
                Date = DateTime.Now.AddDays(-1),
                Category = "Технологии"
            },
            new NewsItem
            {
                Title = "Обновление правил использования",
                Content = "Обратите внимание на изменения в правилах использования сервиса. Все пользователи должны ознакомиться с обновленными условиями.",
                Author = "Модератор",
                Date = DateTime.Now.AddDays(-2),
                Category = "Объявления"
            },
            new NewsItem
            {
                Title = "Плановые технические работы",
                Content = "В ближайшую субботу с 02:00 до 06:00 будут проводиться плановые технические работы. Сервис может быть временно недоступен.",
                Author = "Техподдержка",
                Date = DateTime.Now.AddDays(-3),
                Category = "Технические"
            },
            new NewsItem
            {
                Title = "Новые возможности платформы",
                Content = "Добавлены новые инструменты для работы с документами и улучшен интерфейс пользователя. Попробуйте новые функции!",
                Author = "Разработчик",
                Date = DateTime.Now.AddDays(-4),
                Category = "Новости"
            },
            new NewsItem
            {
                Title = "Выход мобильного приложения",
                Content = "Теперь вы можете пользоваться нашим сервисом с мобильных устройств. Приложение доступно в App Store и Google Play.",
                Author = "Маркетинг",
                Date = DateTime.Now.AddDays(-5),
                Category = "Обновления"
            }
        };

        DisplayItems(allNews.ToArray(), CreateNewsCard);
    }
}
