using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using MediatR;

public class ManagmentEntityUI<T, TEntity>(
    AdminMainView form,
    ObjectCard<TEntity> card,
    SerchEntity<TEntity> serch,
    IParametersButtons<T> parametersButtons,
    IMediator mediator)
    : IView<T>
    where TEntity : Entity, new()
{
    public IViewModel<T> ViewModel => throw new Exception("Не содержит данных");

    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    public Control CreateUI()
    {
        var layout = Layout.CreateColumn()
                .Row()
                    .Column(65).ContentEnd(new CardModule<TEntity>(mediator, serch, card).CreateControl())
                    .Column(35).ContentEnd(new SerchModule<TEntity>(serch).CreateControl())
                .End()
                .Row(80, SizeType.Absolute).Content(new ButtonModuleV2(parametersButtons).CreateControl()).End()
            .Build();

        return layout;
    }
}