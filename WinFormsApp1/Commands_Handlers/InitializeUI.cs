using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public class InitializeUI<TEntity, TViewModel> : InitializeUI<TViewModel>
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{

}

public class InitializeUI<TViewModel> : IRequest
    where TViewModel : IViewModele
{

}

public class InitializeUIHandler<TEntity, TViewModel>(UI<TEntity, TViewModel> ui) : IRequestHandler<InitializeUI<TEntity, TViewModel>>
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    public readonly UI<TEntity, TViewModel> UI = ui;

    public Task Handle(InitializeUI<TEntity, TViewModel> request, CancellationToken cancellationToken)
    {
        UI.InitializeComponents(null);
        return Task.CompletedTask;
    }
}

public class InitializeUIHandler<TViewModel>(IView<TViewModel> ui) : IRequestHandler<InitializeUI<TViewModel>>
    where TViewModel : IViewModele
{
    public Task Handle(InitializeUI<TViewModel> request, CancellationToken cancellationToken)
    {
        ui.InitializeComponents(null);
        return Task.CompletedTask;
    }
}