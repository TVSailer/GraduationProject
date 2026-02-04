using Admin.Commands_Handlers.Managment;
using Logica;
using MediatR;

public record ValidationObjectRequest<T>(T Instance, Action<T> ActionTryValid) : IRequest;


public class ValidationObjectHandler<T>(IMediator mediator) : IRequestHandler<ValidationObjectRequest<T>>
{
    public Task Handle(ValidationObjectRequest<T> request, CancellationToken cancellationToken)
    {
        if (Validatoreg.TryValidObject(request.Instance, out var results))
        {
            request.ActionTryValid.Invoke(request.Instance);
            return Task.CompletedTask;
        }

        if (request.Instance is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));

        return Task.CompletedTask;
    }
}