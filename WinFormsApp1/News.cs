using Logica;

public partial class ViewVisitor : Form
{
    List<NewsItem> allNews = new();

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
            .ControlsAdd(titleLabel, 0, 0);

        var categories = allNews.Select(n => n.Category).Distinct().ToArray();
        var searchPanel = AdvancedSearchExtensions.CreateAdvancedSearchPanel(SearchNews, categories);

        displayItems = new Panel
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
            new RowStyle(SizeType.Absolute, 130),
            new RowStyle(SizeType.Percent, 100F))
            .ControlsAdd(headerPanel, 0, 1)
            .ControlsAdd(searchPanel, 0, 2)
            .ControlsAdd(displayItems, 0, 3);

        Controls.Add(mainTable);
        LoadTestNews();
    }

    private void SearchNews(SearchOptions options)
    {
        var filteredNews = allNews.Where(news =>
        {
            // Поиск по тексту
            var textMatch = string.IsNullOrEmpty(options.SearchText) ||
                           news.Title.Contains(options.SearchText, StringComparison.OrdinalIgnoreCase) ||
                           news.Content.Contains(options.SearchText, StringComparison.OrdinalIgnoreCase);

            // Фильтр по категории
            var categoryMatch = string.IsNullOrEmpty(options.Category) ||
                               news.Category.Equals(options.Category, StringComparison.OrdinalIgnoreCase);

            // Фильтр по дате
            var dateMatch = (!options.DateFrom.HasValue || news.Date >= options.DateFrom.Value) &&
                           (!options.DateTo.HasValue || news.Date <= options.DateTo.Value);

            // Фильтр по автору
            var authorMatch = string.IsNullOrEmpty(options.Author) ||
                             news.Author.Contains(options.Author, StringComparison.OrdinalIgnoreCase);

            return textMatch && categoryMatch && dateMatch && authorMatch;
        }).ToList();

        DisplayFilteredNews(filteredNews, options);
    }

    private void DisplayFilteredNews(List<NewsItem> filteredNews, SearchOptions options)
    {
        displayItems.Controls.Clear();

        // Заголовок с результатами поиска
        if (!string.IsNullOrEmpty(options.SearchText) ||
            !string.IsNullOrEmpty(options.Category) ||
            !string.IsNullOrEmpty(options.Author))
        {
            var resultsLabel = new Label
            {
                Text = $"Найдено новостей: {filteredNews.Count}",
                Font = new Font(style.Font, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };
            displayItems.Controls.Add(resultsLabel);
        }

        int yPosition = 30;

        foreach (var news in filteredNews)
        {
            var newsCard = CreateNewsCard(news, yPosition);
            displayItems.Controls.Add(newsCard);
            yPosition += newsCard.Height + 10;
        }

        displayItems.Height = yPosition;
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
            Size = new Size(displayItems.Width - 25, 180),
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

        var closeButton = elementFactory.CreateButton(Attributes.Close);
        closeButton.Dock = DockStyle.Bottom;
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

public class SearchOptions
{
    public string SearchText { get; set; } = "";
    public string Category { get; set; } = "";
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string Author { get; set; } = "";
    public string Location { get; set; } = "";
    public int? MinRating { get; set; }
    public int? MaxParticipants { get; set; }
}

public static class AdvancedSearchExtensions
{
    public static Panel CreateAdvancedSearchPanel(Action<SearchOptions> searchAction, string[] categories = null)
    {
        var searchPanel = new Panel
        {
            Height = 120,
            Dock = DockStyle.Top,
            Padding = new Padding(10, 5, 10, 5),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.LightGray
        };

        // Основная строка поиска
        var searchLabel = new Label { Text = "Поиск:", Location = new Point(0, 8), Size = new Size(50, 20) };
        var searchBox = new TextBox { Location = new Point(50, 5), Size = new Size(200, 25), PlaceholderText = "Введите текст для поиска..." };

        // Категория
        var categoryLabel = new Label { Text = "Категория:", Location = new Point(260, 8), Size = new Size(70, 20) };
        var categoryCombo = new ComboBox { Location = new Point(330, 5), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        categoryCombo.Items.Add("Все категории");
        if (categories != null)
            categoryCombo.Items.AddRange(categories);
        categoryCombo.SelectedIndex = 0;

        // Дата от
        var dateFromLabel = new Label { Text = "С даты:", Location = new Point(0, 40), Size = new Size(50, 20) };
        var dateFromPicker = new DateTimePicker { Location = new Point(50, 38), Size = new Size(120, 25), Format = DateTimePickerFormat.Short };

        // Дата до
        var dateToLabel = new Label { Text = "По дату:", Location = new Point(180, 40), Size = new Size(60, 20) };
        var dateToPicker = new DateTimePicker { Location = new Point(240, 38), Size = new Size(120, 25), Format = DateTimePickerFormat.Short };

        // Автор/организатор
        var authorLabel = new Label { Text = "Автор:", Location = new Point(370, 40), Size = new Size(50, 20) };
        var authorBox = new TextBox { Location = new Point(420, 38), Size = new Size(150, 25), PlaceholderText = "ФИО автора..." };

        // Кнопки
        var searchButton = new Button { Text = "Применить фильтры", Location = new Point(0, 75), Size = new Size(120, 25) };
        var clearButton = new Button { Text = "Сбросить", Location = new Point(130, 75), Size = new Size(80, 25) };
        var advancedButton = new Button { Text = "Расширенный поиск", Location = new Point(220, 75), Size = new Size(140, 25) };

        // Обработчики
        searchButton.Click += (s, e) =>
        {
            var options = new SearchOptions
            {
                SearchText = searchBox.Text,
                Category = categoryCombo.SelectedIndex > 0 ? categoryCombo.SelectedItem.ToString() : "",
                DateFrom = dateFromPicker.Value.Date,
                DateTo = dateToPicker.Value.Date,
                Author = authorBox.Text
            };
            searchAction(options);
        };

        clearButton.Click += (s, e) =>
        {
            searchBox.Text = "";
            categoryCombo.SelectedIndex = 0;
            dateFromPicker.Value = DateTime.Now.AddMonths(-1);
            dateToPicker.Value = DateTime.Now.AddMonths(1);
            authorBox.Text = "";
            searchAction(new SearchOptions());
        };

        // Устанавливаем разумные даты по умолчанию
        dateFromPicker.Value = DateTime.Now.AddMonths(-1);
        dateToPicker.Value = DateTime.Now.AddMonths(1);

        searchPanel.Controls.AddRange(new Control[]
        {
            searchLabel, searchBox, categoryLabel, categoryCombo,
            dateFromLabel, dateFromPicker, dateToLabel, dateToPicker,
            authorLabel, authorBox, searchButton, clearButton, advancedButton
        });

        return searchPanel;
    }

    public static Panel CreateClubSearchPanel(Action<SearchOptions> searchAction)
    {
        var searchPanel = new Panel
        {
            Height = 150,
            Dock = DockStyle.Top,
            Padding = new Padding(10, 5, 10, 5),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.LightGray
        };

        // Основной поиск
        var searchLabel = new Label { Text = "Название:", Location = new Point(0, 8), Size = new Size(60, 20) };
        var searchBox = new TextBox { Location = new Point(60, 5), Size = new Size(200, 25), PlaceholderText = "Название кружка..." };

        // Категория
        var categoryLabel = new Label { Text = "Категория:", Location = new Point(270, 8), Size = new Size(70, 20) };
        var categoryCombo = new ComboBox { Location = new Point(340, 5), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        categoryCombo.Items.AddRange(new object[] { "Все категории", "IT", "Техника", "Творчество", "Спорт", "Наука", "Интеллектуальные игры" });
        categoryCombo.SelectedIndex = 0;

        // Руководитель
        var leaderLabel = new Label { Text = "Руководитель:", Location = new Point(0, 40), Size = new Size(80, 20) };
        var leaderBox = new TextBox { Location = new Point(85, 38), Size = new Size(150, 25), PlaceholderText = "ФИО руководителя..." };

        // Местоположение
        var locationLabel = new Label { Text = "Место:", Location = new Point(245, 40), Size = new Size(45, 20) };
        var locationBox = new TextBox { Location = new Point(295, 38), Size = new Size(150, 25), PlaceholderText = "Аудитория..." };

        // Рейтинг
        var ratingLabel = new Label { Text = "Рейтинг от:", Location = new Point(0, 75), Size = new Size(70, 20) };
        var ratingCombo = new ComboBox { Location = new Point(75, 72), Size = new Size(80, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        ratingCombo.Items.AddRange(new object[] { "Любой", "1+", "2+", "3+", "4+", "5" });
        ratingCombo.SelectedIndex = 0;

        // Участники
        var participantsLabel = new Label { Text = "Свободных мест:", Location = new Point(165, 75), Size = new Size(100, 20) };
        var participantsCombo = new ComboBox { Location = new Point(270, 72), Size = new Size(100, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        participantsCombo.Items.AddRange(new object[] { "Любое", "Есть места", "Мало мест", "Заполнен" });
        participantsCombo.SelectedIndex = 0;

        // Кнопки
        var searchButton = new Button { Text = "Найти", Location = new Point(380, 72), Size = new Size(80, 25) };
        var clearButton = new Button { Text = "Сбросить", Location = new Point(470, 72), Size = new Size(80, 25) };

        searchButton.Click += (s, e) =>
        {
            var options = new SearchOptions
            {
                SearchText = searchBox.Text,
                Category = categoryCombo.SelectedIndex > 0 ? categoryCombo.SelectedItem.ToString() : "",
                Author = leaderBox.Text,
                Location = locationBox.Text,
                MinRating = ratingCombo.SelectedIndex > 0 ? ratingCombo.SelectedIndex : (int?)null
            };
            searchAction(options);
        };

        clearButton.Click += (s, e) =>
        {
            searchBox.Text = "";
            categoryCombo.SelectedIndex = 0;
            leaderBox.Text = "";
            locationBox.Text = "";
            ratingCombo.SelectedIndex = 0;
            participantsCombo.SelectedIndex = 0;
            searchAction(new SearchOptions());
        };

        searchPanel.Controls.AddRange(new Control[]
        {
            searchLabel, searchBox, categoryLabel, categoryCombo,
            leaderLabel, leaderBox, locationLabel, locationBox,
            ratingLabel, ratingCombo, participantsLabel, participantsCombo,
            searchButton, clearButton
        });

        return searchPanel;
    }
}

