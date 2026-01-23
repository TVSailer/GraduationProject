using Admin.View.Moduls.UIModel;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using WinFormsApp1.View;
using IView = Admin.View.ViewForm.IView;

namespace Admin.View
{
    public class ManagementView<TEntity, TCard> : IView
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
    {
        private Form form;
        private CardModule<TEntity, TCard> cardModule;
        private ButtonModule buttonModule;
        private SerchModule<TEntity> serchModule;

        public ManagementView(
            AdminMainView mainForm,
            ManagmentModelView<TEntity> manager)
        {
            form = mainForm;

            buttonModule = new ButtonModule(manager);
            serchModule = new SerchModule<TEntity>(manager.SerchManagment);
            cardModule = new CardModule<TEntity, TCard>(manager);
        }

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercent(FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .ControlAddIsColumnPercent(cardModule.CreateControl(), 70)
                .ControlAddIsColumnPercent(serchModule.CreateControl(), 30))
            .ControlAddIsRowsAbsolute(buttonModule.CreateControl(), 90);

        public Form InitializeComponents(object? data)
        {
        

            return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(UIEvent()));
        }
    }
}


