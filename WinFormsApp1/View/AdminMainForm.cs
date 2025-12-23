using AdminApp.Forms;
using Logica;


namespace WinFormsApp1.View
{
    public partial class AdminMainView : Form
    {
        public AdminMainView(AdminMainViewModel adminMainViewModel)
        {
            DataContext = adminMainViewModel;
            InitializeComponent();
        }

        public Form InitializeComponent()
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
                .ControlAddIsColumnPercentV2(null, 25)
                .ControlAddIsColumnAbsoluteV2(null, 600)
                .ControlAddIsRowsAbsoluteV2(
                    FactoryElements.LabelTitle("Панель администратора"), 70)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("📰 Управление новостями", () => new NewsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("🎭 Управление мероприятиями", DataContext, "OnLoadEventsManagemetnView"), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("🎨 Управление кружками", () => new LessonsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("👨‍🏫 Управление преподавателями", DataContext, "OnLoadTeachersManagemetnView"), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("👥 Управление пользователями", () => new VisitorsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("📊 Управление посещаемостью", () => new AttendanceManagementForm().ShowDialog()), 50)
                .ControlAddIsColumnPercentV2(null, 25)
                .ControlAddIsRowsPercentV2(null, 25);

        private Control CreateButton(string text, Action action) 
            => FactoryElements.CreateButton(text, action)
                .With(b => b.Font = new Font("Arial", 12, FontStyle.Bold))
                .With(b => b.BackColor = Color.LightGray);
        
        private Control CreateButton(string text, object context, string dataMember) 
            => FactoryElements.CreateButton(text)
                .With(b => b.Font = new Font("Arial", 12, FontStyle.Bold))
                .With(b => b.DataBindings.Add(new Binding("Command", context, dataMember, true)))
                .With(b => b.BackColor = Color.LightGray);
    }

}
