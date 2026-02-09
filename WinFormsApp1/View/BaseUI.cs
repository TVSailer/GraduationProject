using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using System.Windows.Forms;
using Admin.View.AdminMain;
using Admin.ViewModel.AbstractViewModel;

public class BaseUI<TViewData, TEntity>(
    AdminMainView form, 
    TViewData viewData,
    IParametersButtons<TViewData> parametersButtons)
    : IView<TViewData, TEntity>
    where TEntity : Entity, new()
    where TViewData : IFieldData<TEntity>
{
    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    public Control CreateUI()
    {
        return LayoutPanel
            .CreateColumn()
                .Row(0, SizeType.AutoSize).ContentEnd(new FieldEntityModule(ViewField).CreateControl())
                .With(c => {
                    if (ViewField is FieldModelWithImages<TEntity> vm)
                        c.Row().ContentEnd(new ImageModule<TEntity>(vm).CreateControl());
                    else c.Row().End();
                })
                .Row(0, SizeType.AutoSize).ContentEnd(new ButtonModuleV2(parametersButtons.GetButtons(ViewField, this)).CreateControl())
            .Build();
    }

    public TViewData ViewField { get; set; } = viewData;
}