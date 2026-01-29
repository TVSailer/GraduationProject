using Admin.View.Moduls.UIModel;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica;
using IView = Admin.View.ViewForm.IView;

namespace Admin.View
{
    public class ManagementView<TEntity, TCard, TParam> : IView
        where TParam : IParam
        where TEntity : Entity, new()
        where TCard : ObjectCard<TEntity>, new()
    {
        private Form form;
        private CardModule<TEntity, TCard> cardModule;
        private ButtonModuleV2 buttonModule;
        private SerchModule<TEntity> serchModule;

        public ManagementView(
            AdminMainView mainForm,
            CardModule<TEntity, TCard> cardModule,
            SerchManagment<TEntity> serchManagment,
            IParametersButtons<TParam> parametersButtons)
        {
            form = mainForm;

            buttonModule = new ButtonModuleV2(parametersButtons);
            serchModule = new SerchModule<TEntity>(serchManagment);

            this.cardModule = cardModule;
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


