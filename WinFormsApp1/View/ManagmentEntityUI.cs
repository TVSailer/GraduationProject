using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using MediatR;

public class ManagmentEntityUI<TViewData, TEntity, TFieldSearch>(
    AdminMainView form,
    ObjectCard<TEntity> card,
    SearchEntity<TEntity, TFieldSearch> search,
    TViewData viewData,
    IParametersButtons<TViewData> parametersButtons,
    IMediator mediator) 
    : IView<TViewData>, IInitializeSerch<TEntity>
    where TEntity : Entity, new()
    where TFieldSearch : PropertyChange
{
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
                    .Column(70).ContentEnd(new CardModule<TEntity, TFieldSearch>(mediator, search, card).CreateControl())
                    .Column(30).ContentEnd(new SerchModule<TEntity, TFieldSearch>(search).CreateControl())
                .End()
                .Row(80, SizeType.Absolute).Content(new ButtonModuleV2(parametersButtons.GetButtons(viewData)).CreateControl()).End()
            .Build();

        return layout;
    }

    public void SetData(Func<List<TEntity>> data)
    {
        search.SetData(data);
    }
}

