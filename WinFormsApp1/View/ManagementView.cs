using Admin.ViewModel;
using CSharpFunctionalExtensions;
using Logica;
using WinFormsApp1.View;

namespace Admin.View
{
    public abstract class ManagementView<T>
    {
        protected readonly Form form;
        protected readonly ManagmentModelView<T> context;

        public ManagementView(Form form, ManagmentModelView<T> modelView)
        {
            this.form = form;
            context = modelView;
        }

        public Form InitializeComponents()
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(UIEvent()));

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(form.Text), 70)
            .ControlAddIsRowsPercentV2(FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .ControlAddIsColumnPercentV2(LoadCardsPanel(), 80)
                .ControlAddIsColumnPercentV2(LoadSerchPanel(), 20))
            .ControlAddIsRowsAbsoluteV2(LoadButtonPanel(), 90);

        protected abstract Control LoadSerchPanel();

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
                    p.Controls.Add(CreateCard(en)
                    .With(c => c.OnCardClicked +=
                    (s, e) => {
                        if (en is Entity entity)
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

        public abstract ObjectCard<T> CreateCard(T entity);
    }
}


