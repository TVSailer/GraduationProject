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
    TFieldData fieldData,
    IParametersButtons<TFieldData> parametersButtons,
    SearchCardModule<TEntity, TFieldSearch, TFieldDetails> searchCardModule) : IView<TFieldData>
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
            .Row().ContentEnd(searchCardModule
                .CreateControl())
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonModuleV2(parametersButtons.GetButtons(fieldData)).CreateControl())
            .Build();

        return layout;
    }
}