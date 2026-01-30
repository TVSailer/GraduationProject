using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public class InitializeUI<T> : IRequest
{

}

public class InitializeUIHandler<T>(IView<T> ui) : IRequestHandler<InitializeUI<T>>
{
    public Task Handle(InitializeUI<T> request, CancellationToken cancellationToken)
    {
        ui.InitializeComponents(null);
        return Task.CompletedTask;
    }
}
