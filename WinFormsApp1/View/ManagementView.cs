using Admin.View.Moduls.UIModel;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using WinFormsApp1.View;
using IView = Admin.View.ViewForm.IView;

namespace Admin.View
{
    public class ManagementView<TEntity, TCard, TAddingPanel, TDetailsPanel> : IView
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
        where TAddingPanel : IAddingPanel<TEntity>
        where TDetailsPanel : IDetalsPanel<TEntity>
    {
        private readonly Form form;
        private readonly CardModule<TEntity, TCard> cardModule;
        private readonly ButtonModule buttonModule;
        private readonly SerchModule<TEntity> serchModule;

        public ManagementView(
            AdminMainView mainForm, 
            ManagmentModelView<TEntity, TAddingPanel, TDetailsPanel> manager,
            SerchManagment<TEntity> serchManagment)
        {
            form = mainForm;
            buttonModule = new ButtonModule(manager);
            serchModule = new SerchModule<TEntity>(serchManagment);
            cardModule = new CardModule<TEntity, TCard>(serchManagment, e => manager.OnLoadDetailsView.Execute(e));
        }

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercent(FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .ControlAddIsColumnPercent(cardModule.CreateControl(), 80)
                .ControlAddIsColumnPercent(serchModule.CreateControl(), 20))
            .ControlAddIsRowsAbsolute(buttonModule.CreateControl(), 90);

        public Form InitializeComponents(object? data)
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(UIEvent()));
    }
}


