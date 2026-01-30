using Admin.View.Moduls.UIModel;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica;
using MediatR;


public class UIBuilder<T>
{
    private readonly IMediator mediator;
    private readonly Form form;
    private readonly IParametersButtons<T> parametersButtons;
    private List<List<IUIModel>> uiModels = [new()];


    public UIBuilder(
        AdminMainView mainView,
        IParametersButtons<T> parametersButtons)
    {
        form = mainView;
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
                            sloy.ControlAddIsColumnPercent(ui.CreateControl()))).EndTabel()));
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

    public UIBuilder<T> WithCardPanel<TEntity>(ObjectCard<TEntity> card, SerchEntity<TEntity> serch)
        where TEntity : Entity, new()
    {
        uiModels[^1].Add(new CardModule<TEntity>(mediator, serch, card));
        return this;
    }

    public UIBuilder<T> WithSerchPanel<TEntity>(SerchEntity<TEntity> serch)
        where TEntity : Entity, new()
    {
        uiModels[^1].Add(new SerchModule<TEntity>(serch));
        return this;
    }
}