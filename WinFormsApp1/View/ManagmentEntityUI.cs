using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using MediatR;

namespace Admin.View;

public class ManagmentEntityUi<TFieldData, TEntity, TFieldSearch, TFieldDetails>(
    AdminMainView form,
    ControlView control,
    ObjectCard<TEntity> card,
    SearchEntity<TEntity, TFieldSearch> search,
    TFieldData viewData,
    IParametersButtons<TFieldData> parametersButtons) 
    : IView<TFieldData>
    where TEntity : Entity, new()
    where TFieldSearch : PropertyChange, IFieldData
    where TFieldDetails : IFieldData<TEntity>
{
    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUi()));
    }

    public Control CreateUi()
    {
        var layout = LayoutPanel.CreateColumn()
            .Row()
            .Column(70).ContentEnd(new CardModule<TEntity, TFieldSearch, TFieldDetails>(search, card, control).CreateControl())
            .Column(30).ContentEnd(new SerchModule<TEntity, TFieldSearch>(search).CreateControl())
            .End()
            .Row(80, SizeType.Absolute).Content(new ButtonModuleV2(parametersButtons.GetButtons(viewData)).CreateControl()).End()
            .Build();

        return layout;
    }
}