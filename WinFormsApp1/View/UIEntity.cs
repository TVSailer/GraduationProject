using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using CSharpFunctionalExtensions;
using Logica;

public class UIEntity<TEntity, TViewModel> : IView<TEntity>
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    private AdminMainView form;
    private ImageModule<TEntity> imagePanel;
    private ButtonModule buttonModule;
    private FieldEntityModule fieldInfo;
    public IViewModele<TEntity> ViewModele { get; set; }

    public UIEntity(AdminMainView mainView, TViewModel viewModel)
    {
        form = mainView;
        ViewModele = viewModel;

        if (viewModel is ViewModelWithImages<TEntity> vm)
            imagePanel = new ImageModule<TEntity>(vm);
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
            .ControlAddIsRowsPercent(imagePanel is null ? new Control() : imagePanel.CreateControl())
            .ControlAddIsRowsAbsolute(buttonModule.CreateControl());
    }
}

