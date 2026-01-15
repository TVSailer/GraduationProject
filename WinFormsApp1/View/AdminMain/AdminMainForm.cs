using Admin.View.ViewForm;
using Logica;


namespace WinFormsApp1.View
{
    public partial class AdminMainView : Form, IView
    {
        public AdminMainView(AdminMainViewModel adminMainViewModel)
        {
            DataContext = adminMainViewModel;
            InitializeComponents();
        }

        public Form InitializeComponents()
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

        public Form InitializeComponents(object? data)
        {
            throw new NotImplementedException();
        }
    }

}
