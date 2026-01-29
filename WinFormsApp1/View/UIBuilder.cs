using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica;
using MediatR;

public class UIBuilder<T>(AdminMainView mainView, IMediator mediator) : UIBuilder(mainView, mediator)
    where T : IParam;

public class UIBuilder : IView
{
    public IMediator Mediator { get; }
    public IViewModele ViewModele { get; }

    private AdminMainView form;
    private List<List<IUIModel>> uiModels = [];


    public UIBuilder(AdminMainView mainView, IMediator mediator)
    {
        Mediator = mediator;
        form = mainView;
    }

    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    private Control? CreateUI()
    {
        return FactoryElements.TableLayoutPanel()
            .With(t =>
                uiModels.ForEach(sloyUI =>
                    t.StartNewRowTableAbsolute().With(sloy =>
                        sloyUI.ForEach(ui =>
                            sloy.ControlAddIsColumnPercent(ui.CreateControl())))));
        // .ControlAddIsRowsAbsolute(fieldInfo.CreateControl())
        // .ControlAddIsRowsPercent(imagePanel is null ? new Control() : imagePanel.CreateControl())
        // .ControlAddIsRowsAbsolute(buttonModule.CreateControl());
    }

    public UIBuilder NextRow()
        => this.With(_ => uiModels.Add(new List<IUIModel>()));

    public UIBuilder With(Func<IUIModel> build)
        => this.With(_ => uiModels[^1].Add(build.Invoke()));

    public UIBuilder WithImgPanel<T>(ViewModelWithImages<T> viewModel) where T : Entity, new()
        => this
            .With(_ => uiModels[^1].Add(new ImageModule<T>(viewModel)));

    public UIBuilder WithButtonPanel<T>(IParametersButtons<T> parametersButtons) where T : IParam
        => this
            .With(_ => uiModels[^1].Add(new ButtonModuleV2(parametersButtons)));

    public UIBuilder WithFieldPanel(IViewModele viewModele)
        => this
            .With(_ => uiModels[^1].Add(new FieldEntityModule(viewModele)));

    public UIBuilder WithCardPanel<TEntity, TCard>(SerchManagment<TEntity> serchManagment)
        where TCard : ObjectCard<TEntity>, new()
        where TEntity : Entity, new()
        => this
            .With(_ => uiModels[^1].Add(new CardModule<TEntity, TCard>(Mediator, serchManagment)));

    public UIBuilder WithSerchPanel<TEntity>(SerchManagment<TEntity> serchManagment)
        where TEntity : Entity, new()
        => this
            .With(_ => uiModels[^1].Add(new SerchModule<TEntity>(serchManagment)));
}