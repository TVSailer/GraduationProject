
using Admin.ViewModel.Lesson;
using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;
using WinFormsApp1.View.Teachers;

namespace Admin.View.Lesson
{
    public class LessonManagementView : AbstractManagementView
    {
        private new readonly LessonManagmentViewModel context;

        public LessonManagementView(AdminMainView mainForm, LessonManagmentViewModel viewModel) : base(mainForm, viewModel)
        {
            context = viewModel;

            form.Text = "🎨 Управление кружками";
        }

        protected override Control LoadCardsPanel()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(context.LessonEntities))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }

        private void AddCard(FlowLayoutPanel p)
            => context.LessonEntities
            .ForEach(
                l =>
                {
                    p.Controls.Add(new LessonCard(l)
                    .With(c => c.OnCardClicked +=
                    (s, e) =>
                    {
                        //using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                        //    scope.GetService<EventDetailsView>(l.Id).InitializeComponents();
                    }));
                });
    }
}


