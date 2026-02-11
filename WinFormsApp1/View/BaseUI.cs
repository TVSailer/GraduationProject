using System.Windows.Forms;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

public class BaseUI<TFieldData, TEntity>(
    AdminMainView form, 
    TFieldData viewData,
    IParametersButtons<TFieldData> parametersButtons)
    : IView<TFieldData, TEntity>
    where TEntity : Entity, new()
    where TFieldData : IFieldData<TEntity>
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
                .Row(0, SizeType.AutoSize).ContentEnd(new ButtonModuleV2(parametersButtons.GetButtons(ViewField)).CreateControl())
            .Build();
    }

    public TFieldData ViewField { get; set; } = viewData;
}