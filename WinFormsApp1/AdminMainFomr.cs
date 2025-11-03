using Logica;
using Logica.Extension;


namespace AdminApp.Forms
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
            => this
                .With(m => m.Text = "Панель администратора")
                .With(m => m.WindowState = FormWindowState.Maximized)
                .With(m => m.StartPosition = FormStartPosition.CenterParent)
                .With(m => m.BackColor = Color.White)
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(MainMenu()));

        private TableLayoutPanel MainMenu()
            => new TableLayoutPanel()
                .With(t => t.Padding = new Padding(30))
                .With(t => t.Dock = DockStyle.Fill)
                .ControlAddIsColumnPercentV2(null, 25)
                .ControlAddIsColumnAbsoluteV2(null, 600)
                .ControlAddIsRowsAbsoluteV2(
                    new Label().LabelTitle("Панель администратора"), 70)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("📰 Управление новостями", () => new NewsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("🎭 Управление мероприятиями", () => InitializeComponentEvent()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("🎨 Управление кружками", () => new LessonsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("👨‍🏫 Управление преподавателями", () => new TeachersManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("👥 Управление пользователями", () => new VisitorsManagementForm().ShowDialog()), 50)
                .ControlAddIsRowsAbsoluteV2(
                    CreateButton("📊 Управление посещаемостью", () => new AttendanceManagementForm().ShowDialog()), 50)
                .ControlAddIsColumnPercentV2(null, 25)
                .ControlAddIsRowsPercentV2(null, 25);

        private Button CreateButton(string text, Action action) 
            => FactoryElements.CreateButton(text, action)
                .With(b => b.Font = new Font("Arial", 12, FontStyle.Bold))
                .With(b => b.BackColor = Color.LightGray);
    }
}
