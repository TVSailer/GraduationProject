using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica;
using System.Reflection;


public class UI<TEntity, TViewModel> : IView<TViewModel>
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    //TODO: будущий мусор
    private ButtonModule buttonModule;


    private AdminMainView form;
    private ImageModule<TEntity> imagePanel;
    private IUIModel<Button> buttonModuleV2;
    private FieldEntityModule fieldInfo;
    private ObjectCard<TEntity> cardModule;

    public IViewModele ViewModele { get; set; }

    public UI(AdminMainView mainView, TViewModel viewModel)
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


