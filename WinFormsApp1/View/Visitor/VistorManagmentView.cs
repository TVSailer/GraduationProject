using Admin.ViewModel.Visitor;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.View;
using WinFormsApp1.View.Teachers;

namespace Admin.View.Visitor
{
    public class VistorManagmentView : AbstractManagementView
    {
        private new readonly VisitorManagementModelView context;

        public VistorManagmentView(AdminMainView mainForm, VisitorManagementModelView modelView) : base(mainForm, modelView)
        {
            context = modelView;
            form.Text = "👥 Управление посетителями";
        }

        protected override Control LoadCardsPanel()
            => FactoryElements.TableLayoutPanel()
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(context.VisitorEntities))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(TableLayoutPanel p)
        {
            context.VisitorEntities
            .ForEach(
                v =>
                {
                    p.ControlAddIsRowsAbsoluteV2(new VisitorCard(v)
                   .With(c => c.OnCardClicked +=
                   (s, e) =>
                   {
                       //using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                       //    scope.GetService<EventDetailsView>(v.Id).InitializeComponents();
                   }), 60);
                });

            p.ControlAddIsRowsPercentV2();
        }


        protected override Control LoadSerchPanel()
        {
            return new Panel();
        }
    }
}
