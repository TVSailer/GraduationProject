using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public record SendEntityRequest<T>(T Entity) : IRequest
    where T : Entity, new();

public class InitializeDetailsPanelHandler<TEntity, TDetailsViewModel>(IView<TDetailsViewModel, TEntity> detailsPanel) : IRequestHandler<SendEntityRequest<TEntity>>
    where TEntity : Entity, new()
    where TDetailsViewModel : IViewData<TEntity>
{
    public Task Handle(SendEntityRequest<TEntity> request, CancellationToken cancellationToken)
    {
        detailsPanel.InitializeComponents(null);
        detailsPanel.ViewData.Entity.SetEntity(request.Entity);
        return Task.CompletedTask;
    }
}


