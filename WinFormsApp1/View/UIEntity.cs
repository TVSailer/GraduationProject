using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using CSharpFunctionalExtensions;
using Logica;
using WinFormsApp1.View;



public class UIEntity<TEntity, TViewModel> : IView
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    private readonly AdminMainView form;
    private readonly ImageModule<TEntity> imagePanel;
    private readonly ButtonModule buttonModule;
    private readonly FieldEntityModule fieldInfo;

    public UIEntity(AdminMainView mainView, TViewModel viewModel)
    {
        form = mainView;

        imagePanel = new ImageModule<TEntity>(viewModel);
        buttonModule = new ButtonModule(viewModel);
        fieldInfo = new FieldEntityModule(viewModel);
    }

    public Form InitializeComponents(object? data)
    {
        return form
        .With(m => m.Controls.Clear())
        .With(m => m.Controls.Add(CreateUI()));
    }

    private Control? CreateUI()
    {
        return FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsolute(fieldInfo.CreateControl())
            .ControlAddIsRowsPercent(imagePanel.CreateControl())
            .ControlAddIsRowsAbsolute(buttonModule.CreateControl());
    }
}

