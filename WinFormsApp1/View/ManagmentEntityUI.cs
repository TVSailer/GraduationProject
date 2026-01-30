using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;

public class ManagmentEntityUI<T, TEntity> : IView<T>
    where TEntity : Entity, new()
{
    private readonly UIBuilder<T> builderUi;
    private readonly ObjectCard<TEntity> card;
    private readonly SerchEntity<TEntity> serch;
    private readonly IParametersButtons<T> parametersButtons;

    public IViewModel<T> ViewModel => throw new Exception("Не содержит данных");

    public ManagmentEntityUI(UIBuilder<T> builderUI, ObjectCard<TEntity> card, SerchEntity<TEntity> serch)
    {
        builderUi = builderUI;
        this.card = card;
        this.serch = serch;
    }

    public Form InitializeComponents(object? data)
    {
        builderUi
            .WithCardPanel(card, serch)
            .WithSerchPanel(serch)
            .NextRow()
            .WithButtonPanel();

        return builderUi.InitializeComponents(data);
    }
}