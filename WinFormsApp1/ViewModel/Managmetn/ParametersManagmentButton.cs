using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using MediatR;
using Ninject.Parameters;

public class ParametersManagmentButton<T, TEntity, TViewModelExit, TAddingPanel>(IMediator mediator) : IParametersButtons<T>
    where TViewModelExit : IViewModele
    where TAddingPanel : IAddingPanel<TEntity>
    where TEntity : Entity, new()
{
    public List<ButtonInfo> buttons =>
    [
        new("Назад", _ => mediator.Send(new InitializeUI<TViewModelExit>())),
        new("Добавить", _ => mediator.Send(new InitializeUI<TAddingPanel>()))
    ];
}

// public class ManagmentModelView<TEntity> : PropertyChange, IViewModele
//     where TEntity : Entity, new()
// {
//     public SerchManagment<TEntity> SerchManagment { get; private set; }
//
//     [ButtonInfoUI("Добавить")]
//     public ICommand OnLoadAddingView { get; private set; }
//
//     [ButtonInfoUI("Назад")]
//     public ICommand OnBack { get; private set; }
//
//     public ICommand OnLoadDetailsView { get; private set; }
//
//     public ManagmentModelView(
//         AdminMainView mainForm,
//         SerchManagment<TEntity> serchManagment,
//         IView<TEntity>[] view)
//     {
//         SerchManagment = serchManagment;
//         var detailsPanel = GetEntity(view, nameof(OnLoadDetailsView));
//         var addingPanel = GetEntity(view, nameof(OnLoadAddingView));
//
//         OnBack = new MainCommand(
//             _ => mainForm.InitializeComponents());
//
//         OnLoadDetailsView = new MainCommand(
//             obj =>
//             {
//                 if (obj is TEntity val)
//                 {
//                     detailsPanel.InitializeComponents(null);
//                 }
//                 else throw new ArgumentException();
//             });
//
//         OnLoadAddingView = new MainCommand(
//             _ => addingPanel.InitializeComponents(null));
//     }
//
//     public IView<TEntity> GetEntity(IView<TEntity>[] viewModeles, string nameCommand)
//         => viewModeles
//             .First(v => v.ViewModele
//                 .GetType()
//                 .GetCustomAttribute<LinkingCommandAttribute>()!.NameCommand
//                 .Equals(nameCommand)) ?? throw new Exception();
// }