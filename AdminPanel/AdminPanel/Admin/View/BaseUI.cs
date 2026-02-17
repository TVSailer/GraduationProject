using Admin.Args;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.AbstractViewModel;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

public class BaseUI<TFieldData, TEntity, TButtons>(
    AdminMainUi form, 
    TFieldData viewData,
    TButtons parametersButtons)
    : View<TFieldData, TEntity>(viewData)
    where TEntity : Entity, new()
    where TFieldData : IFieldData<TEntity>
    where TButtons : IButtons<ViewButtonClickArgs<TEntity, TFieldData>>
{
    protected override Control CreateUi()
    {
        return LayoutPanel.CreateColumn()
                .Row(0, SizeType.AutoSize).ContentEnd(new FieldLayoutPanel(ViewField).CreateControl())
                .With(c => {
                    if (ViewField is FieldModelWithImages<TEntity> vm)
                        c.Row().ContentEnd(new ImageLayoutPanel<TEntity>(vm).CreateControl());
                    else c.Row().End();
                })
                .Row(0, SizeType.AutoSize).ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<TEntity, TFieldData>>()
                    .SetClickedData(this, new ViewButtonClickArgs<TEntity, TFieldData>(ViewField))
                    .SetButtons(parametersButtons))
            .Build();
    }
}