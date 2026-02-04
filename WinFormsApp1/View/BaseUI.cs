using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;
using System.Windows.Forms;

public class BaseUI<T, TEntity>(
    AdminMainView form, 
    IViewModel<T> viewModel, 
    IParametersButtons<T> parametersButtons)
    : IView<T>
    where TEntity : Entity, new()
{
    public IViewModel<T> ViewModel { get; } = viewModel;

    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    public Control CreateUI()
    {
        return Layout
            .CreateColumn()
                .Row(400, SizeType.Absolute).ContentEnd(new FieldEntityModule(ViewModel).CreateControl())
                .With(c => {
                    if (ViewModel is ViewModelWithImages<TEntity> vm)
                        c.Row().ContentEnd(new ImageModule<TEntity>(vm).CreateControl());
                })
                .Row(160, SizeType.Absolute).ContentEnd(new ButtonModuleV2(parametersButtons).CreateControl())
            .Build();
    }
}