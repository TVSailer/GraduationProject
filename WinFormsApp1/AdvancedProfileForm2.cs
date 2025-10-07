using Logica;

public partial class ViewVisitor : Form
{
    private Panel newsPanel;

    private void LoadNewsMenuStrip()
    {
        var titleLabel = new Label
        {
            Text = "Последние новости",
            Font = style.TitleFont,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            ForeColor = Color.DarkBlue
        };

        var headerPanel = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
            new ColumnStyle(SizeType.Percent, 100F),
            new ColumnStyle(SizeType.Absolute, 100))
            .AddingRowsStyles()
            .ControlsAdd(titleLabel, 0, 0)
            .ControlsAdd(elementFactory.CreateButton("Обновить"), 1, 0);

        newsPanel = new Panel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            AutoScroll = true
        };

        var mainTable = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles()
            .AddingRowsStyles(
            new RowStyle(SizeType.Absolute, 10),
            new RowStyle(SizeType.Absolute, 70),
            new RowStyle(SizeType.Percent, 100F))
            .ControlsAdd(headerPanel, 0, 1)
            .ControlsAdd(newsPanel, 0, 2);

        Controls.Add(mainTable);
        LoadTestNews();
    }

    private void LoadTestNews()
    {
        // Тестовые данные новостей
        var newsItems = new[]
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

        DisplayNewsItems(newsItems);
    }
    private void DisplayNewsItems(NewsItem[] newsItems)
    {
        newsPanel.Controls.Clear();

        int yPosition = 10;

        foreach (var news in newsItems)
        {
            var newsCard = CreateNewsCard(news, yPosition);
            newsPanel.Controls.Add(newsCard);
            yPosition += newsCard.Height + 10;
        }

        newsPanel.Height = yPosition;
    }

    private TableLayoutPanel CreateNewsCard(NewsItem news, int yPosition)
    {
        var titleLabel = new LinkLabel
        {
            Text = news.Title,
            Font = style.TitleFont,
            LinkColor = Color.DarkBlue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        titleLabel.Click += (s, e) => ShowNewsDetails(news);

        var infoLabel = new Label
        {
            Text = $"{news.Author} • {news.Date:dd.MM.yyyy} • {news.Category}",
            Font = new Font(style.Font, FontStyle.Italic),
            ForeColor = Color.Gray,
            Dock = DockStyle.Fill
        };

        var contentLabel = new Label
        {
            Text = news.Content,
            Font = style.Font,
            ForeColor = Color.Black,
            Dock = DockStyle.Fill
        };

        var tableCard = new TableLayoutPanel {
            Location = new Point(0, yPosition),
            Size = new Size(newsPanel.Width - 25, 180),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(15),
        };

        tableCard
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 25),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 80))
            .ControlsAdd(titleLabel, 0, 0)
            .ControlsAdd(infoLabel, 0, 1)
            .ControlsAdd(contentLabel, 0, 2);

        return tableCard;
    }

    private void ShowNewsDetails(NewsItem news)
    {
        var detailsForm = new Form
        {
            Text = news.Title,
            Size = new Size(600, 800),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = news.Title,
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var infoLabel = new Label
        {
            Text = $"{news.Author} • {news.Date:dd.MM.yyyy HH:mm} • {news.Category}",
            Font = new Font(style.Font, FontStyle.Italic),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.Gray
        };

        var contentText = new TextBox
        {
            Font = new Font(Font.FontFamily ,12),
            Text = news.Content,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.None,
            BackColor = SystemColors.Window
        };

        var closeButton = elementFactory.CreateButton("Закрыть");
        closeButton.Dock = DockStyle.Bottom;
        closeButton.Height = 35;
        closeButton.Click += (s, e) => detailsForm.Close();

        detailsForm.Controls.Add(contentText);
        detailsForm.Controls.Add(infoLabel);
        detailsForm.Controls.Add(titleLabel);
        detailsForm.Controls.Add(closeButton);

        detailsForm.ShowDialog();
    }

    // Класс для представления новости
    private class NewsItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
