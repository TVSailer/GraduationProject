using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

public class BaseUI<T, TEntity> : IView<T>
    where TEntity : Entity, new()
{
    private readonly UIBuilder<T> builderUi;
    public IViewModel<T> ViewModel { get; }

    public BaseUI(UIBuilder<T> builderUI, IViewModel<T> viewModel)
    {
        builderUi = builderUI;
        ViewModel = viewModel;
    }

    public Form InitializeComponents(object? data)
    {
        builderUi
            .WithButtonPanel()
            .NextRow()
            .WithFieldPanel(ViewModel);

        if (ViewModel is ViewModelWithImages<TEntity> vm)
            builderUi
                .NextRow()
                .WithImgPanel(vm);

        return builderUi.InitializeComponents(data);
    }
}