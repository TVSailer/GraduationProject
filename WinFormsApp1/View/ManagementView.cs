using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using Admin.View.ViewForm;
using Admin.ViewModels;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;
using Microsoft.EntityFrameworkCore.Metadata;
using WinFormsApp1.View;
using IView = Admin.View.ViewForm.IView;

namespace Admin.View
{
    public class ManagementView<TEntity, TCard> : IView
        where TEntity : Entity 
        where TCard : ObjectCard<TEntity>, new()
    {
        protected readonly Form form;
        protected readonly ManagmentModelView<TEntity> context;

        public ManagementView(AdminMainView mainForm, ManagmentModelView<TEntity> manager)
        {
            form = mainForm;
            context = manager;
        }

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .ControlAddIsColumnPercentV2(LoadCardsPanel(), 80)
                .ControlAddIsColumnPercentV2(LoadSerchPanel(), 20))
            .ControlAddIsRowsAbsoluteV2(LoadButtonPanel(), 90);

        protected virtual Control LoadSerchPanel()
        {
            return new Panel();
        }

        protected virtual Control LoadCardsPanel()
            => new FlowLayoutPanel()
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.AutoScroll = true)
            .With(p => p.Padding = new Padding(10))
            .With(p => context.PropertyChanged += (obj, propCh) =>
            {
                if (propCh.PropertyName == nameof(context.DataEntitys))
                {
                    p.Controls.Clear();
                    AddCard(p);
                }
            })
            .With(AddCard);

        private void AddCard(FlowLayoutPanel p)
            => context.DataEntitys
            .ForEach(
                en =>
                {
                    p.Controls.Add(new TCard().Initialize(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is TEntity entity)
                            context.OnLoadDetailsView.Execute(entity);
                        else throw new ArgumentException();
                    }));
                });

        protected virtual TableLayoutPanel LoadButtonPanel()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить", context, "OnLoadAddingView"), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 40);


        public Form InitializeComponents(object? data)
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(UIEvent()));
    }
}


