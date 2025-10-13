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

    private void LoadTestEvents()
    {
        var eventItems = new[]
        {
        new EventItem
        {
            Title = "Хакатон по разработке ПО",
            Description = "Примите участие в 48-часовом марафоне программирования. Создайте инновационное решение и выиграйте призы!",
            Date = DateTime.Now.AddDays(7),
            Location = "Главный корпус, ауд. 301",
            Category = "Технологии",
            RegistrationLink = "https://example.com/hackathon-register",
            Organizer = "IT-отдел",
            MaxParticipants = 100,
            CurrentParticipants = 67
        },
        new EventItem
        {
            Title = "Мастер-класс по ораторскому искусству",
            Description = "Научитесь уверенно выступать перед аудиторией. Практические упражнения и индивидуальные консультации.",
            Date = DateTime.Now.AddDays(3),
            Location = "Конференц-зал",
            Category = "Личностное развитие",
            RegistrationLink = "https://example.com/public-speaking",
            Organizer = "Центр карьеры",
            MaxParticipants = 30,
            CurrentParticipants = 28
        },
        new EventItem
        {
            Title = "Научная конференция 'Инновации-2024'",
            Description = "Ежегодная конференция с участием ведущих ученых и исследователей. Презентации, дискуссии, нетворкинг.",
            Date = DateTime.Now.AddDays(14),
            Location = "Актовый зал",
            Category = "Наука",
            RegistrationLink = "https://example.com/innovation-conference",
            Organizer = "Научный отдел",
            MaxParticipants = 200,
            CurrentParticipants = 145
        },
        new EventItem
        {
            Title = "Воркшоп по проектной деятельности",
            Description = "Практическое руководство по управлению проектами. От идеи до реализации под руководством экспертов.",
            Date = DateTime.Now.AddDays(5),
            Location = "Бизнес-инкубатор",
            Category = "Образование",
            RegistrationLink = "https://example.com/project-workshop",
            Organizer = "Бизнес-школа",
            MaxParticipants = 50,
            CurrentParticipants = 32
        },
        new EventItem
        {
            Title = "Выставка современных технологий",
            Description = "Ознакомьтесь с последними достижениями в области робототехники, VR/AR и искусственного интеллекта.",
            Date = DateTime.Now.AddDays(10),
            Location = "Выставочный центр",
            Category = "Технологии",
            RegistrationLink = "https://example.com/tech-expo",
            Organizer = "Технопарк",
            MaxParticipants = 500,
            CurrentParticipants = 320
        }};

        DisplayItems(eventItems, CreateEventCard);
    }
}
