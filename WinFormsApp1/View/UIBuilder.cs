using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica;
using MediatR;
using Microsoft.Office.Interop.Word;


// public class UIBuilder<T>(AdminMainView mainView, IMediator mediator) : UIBuilder(mainView, mediator)
//    where T : IParam;

public class UIBuilder<T> : IView<T>
    where T : IParam
{
    public IViewModel<T> ViewModel { get; }
    private readonly IMediator mediator;
    private readonly Form form;
    private readonly IParametersButtons<T> parametersButtons;
    private List<List<IUIModel>> uiModels = [new()];


    public UIBuilder(
        AdminMainView mainView, 
        IMediator mediator, 
        IParametersButtons<T> parametersButtons,
        IViewModel<T> viewModel)
    {
        form = mainView;
        ViewModel = viewModel;
        this.mediator = mediator;
        this.parametersButtons = parametersButtons;
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

    public UIBuilder<T> NextRow()
        => this.With(_ => uiModels.Add(new List<IUIModel>()));

    public UIBuilder<T> With(Func<IUIModel> build)
        => this.With(_ => uiModels[^1].Add(build.Invoke()));

    public UIBuilder<T> WithImgPanel<TEntity>(ViewModelWithImages<TEntity> viewModel) where TEntity : Entity, new()
        => this
            .With(_ => uiModels[^1].Add(new ImageModule<TEntity>(viewModel)));

    public UIBuilder<T> WithButtonPanel()
        => this
            .With(_ => uiModels[^1].Add(new ButtonModuleV2(parametersButtons)));

    public UIBuilder<T> WithFieldPanel(IViewModel<T> viewModele)
        => this
            .With(_ => uiModels[^1].Add(new FieldEntityModule(viewModele)));

    public UIBuilder<T> WithCardPanel<TEntity, TCard>()
        where TCard : ObjectCard<TEntity>, new()
        where TEntity : Entity, new()
    {
        if (ViewModel is SerchEntity<TEntity> searchEntity)
            uiModels[^1].Add(new CardModule<TEntity, TCard>(mediator, searchEntity));

        else throw new ArgumentException();

        return this;
    }

    public UIBuilder<T> WithSerchPanel<TEntity, TSearch>()
        where TEntity : Entity, new()
    {
        if (ViewModel is SerchEntity<TEntity> searchEntity)
            uiModels[^1].Add(new SerchModule<TEntity>(searchEntity));

        else throw new ArgumentException();

        return this;
    }
}