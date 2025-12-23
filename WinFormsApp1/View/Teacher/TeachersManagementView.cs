using Admin.View;
using Admin.ViewModel.Teachers;
using Logica;

namespace WinFormsApp1.View.Teachers
{
    public partial class TeachersManagementView : AbstractManagementView
    {
        private readonly TeacherManagementModelView context;

        public TeachersManagementView(AdminMainView mainForm, TeacherManagementModelView modelView) : base(mainForm, modelView)
        {
            form = mainForm;
            context = modelView;

            form.Text = "👨‍🏫 Управление преподавателями";
        }

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }

        protected override Control LoadCardsPanel()
            => new TableLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == "EventEntities")
                {
                    p.Controls.Clear();
                    AddEventCard(p);
                }
            })
            .With(AddEventCard);

        private void AddEventCard(TableLayoutPanel p)
        {
            context.TeacherEntities
            .ForEach(
                t =>
                {
                    p.ControlAddIsRowsAbsoluteV2(new TeacherCard(t)
                   .With(c => c.OnCardClicked +=
                   (s, e) =>
                   {
                       //using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                       //    scope.GetService<EventDetailsView>(t.Id).InitializeComponents();
                   }), 60);
                });

            p.ControlAddIsRowsPercentV2();
        }

    }
}
