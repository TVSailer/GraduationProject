using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public record RecoveryPanelRequest<T> : IRequest
    where T : IFieldData;

public class RecoveryPanelHandler<TEntity, T>(IView<T, TEntity> detailsPanel, MementoView memento) : IRequestHandler<RecoveryPanelRequest<T>>
    where T : IFieldData<TEntity>
    where TEntity : Entity, new()
{
    public Task Handle(RecoveryPanelRequest<T> request, CancellationToken cancellationToken)
    {
        //detailsPanel.ViewData = memento.State;
        detailsPanel.InitializeComponents(null);
        return Task.CompletedTask;
    }
}