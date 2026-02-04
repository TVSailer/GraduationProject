using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Logica;


public partial class AdminMainView : Form, IView<AdminMainViewModel>
{
    public IViewModel<AdminMainViewModel> ViewModel { get; }

    public AdminMainView(AdminMainViewModel adminMainViewModel)
    {
        DataContext = adminMainViewModel;
        InitializeComponents(null);
    }

    public Form InitializeComponents(object? data)
        => this
            .With(m => m.Controls.Clear())
            .With(m => m.Text = "Панель администратора")
            .With(m => m.WindowState = FormWindowState.Maximized)
            .With(m => m.StartPosition = FormStartPosition.CenterParent)
            .With(m => m.BackColor = Color.White)
            .With(m => m.Controls.Add(MainMenu()));

    private TableLayoutPanel MainMenu()
        => new TableLayoutPanel()
            .With(t => t.Padding = new Padding(30))
            .With(t => t.Dock = DockStyle.Fill)
            .ControlAddIsColumnPercent(25)
            .ControlAddIsColumnAbsolute(600)
            .ControlAddIsRowsAbsolute(
                FactoryElements.LabelTitle("Панель администратора"), 70)
            .ControlAddIsRowsAbsolute(
                CreateButton("📰 Управление новостями", DataContext, "OnLoadNewsManagemetnView"), 50)
            .ControlAddIsRowsAbsolute(
                CreateButton("🎭 Управление мероприятиями", DataContext, "OnLoadEventsManagemetnView"), 50)
            .ControlAddIsRowsAbsolute(
                CreateButton("🎨 Управление кружками", DataContext, "OnLoadLessonsManagemetnView"), 50)
            .ControlAddIsRowsAbsolute(
                CreateButton("👨‍🏫 Управление преподавателями", DataContext, "OnLoadTeachersManagemetnView"), 50)
            .ControlAddIsRowsAbsolute(
                CreateButton("👥 Управление посетителями", DataContext, "OnLoadVisitorsManagemetnView"), 50)
            .ControlAddIsRowsAbsolute(
                CreateButton("📊 Управление посещаемостью", null), 50)
            .ControlAddIsColumnPercent(25)
            .ControlAddIsRowsPercent(25);

    private Control CreateButton(string text, Action action)
        => FactoryElements.Button(text, action)
            .With(b => b.Font = new Font("Arial", 12, FontStyle.Bold))
            .With(b => b.BackColor = Color.LightGray);

    private Control CreateButton(string text, object context, string dataMember)
        => FactoryElements.Button(text)
            .With(b => b.Font = new Font("Arial", 12, FontStyle.Bold))
            .With(b => b.DataBindings.Add(new Binding("Command", context, dataMember, true)))
            .With(b => b.BackColor = Color.LightGray);

}

