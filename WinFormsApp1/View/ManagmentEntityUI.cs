using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

public class ManagmentEntityUI<T, TEntity, TCard> : IView<T>
    where T : IParam
    where TEntity : Entity, new()
    where TCard : ObjectCard<TEntity>, new()
{
    private readonly UIBuilder<T> builderUi;
    private readonly IParametersButtons<T> parametersButtons;

    public IViewModel<T> ViewModel { get; }

    public ManagmentEntityUI(UIBuilder<T> builderUI)
    {
        builderUi = builderUI;
        ViewModel = builderUI.ViewModel;
    }

    public Form InitializeComponents(object? data)
    {
        builderUi
            .WithCardPanel<TEntity, TCard>()
            .WithSerchPanel<TEntity, T>()
            .NextRow()
            .WithButtonPanel();

        return builderUi.InitializeComponents(data);
    }
}