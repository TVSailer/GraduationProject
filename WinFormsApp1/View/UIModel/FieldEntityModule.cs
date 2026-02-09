using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica.Extension;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class FieldEntityModule : IUIModel
{
    private readonly PropertyChange context;
    private readonly List<FieldInfoUiAttribute> fieldInfo;

    public FieldEntityModule(object context)
    {
        fieldInfo = context.GetType().GetAttributes<FieldInfoUiAttribute>();

        if (context is not PropertyChange pc)
            throw new ArgumentException("Переданный ViewModelEntity не наследует класс PropertyChange");

        this.context = pc;
    }

    public Control CreateControl()
    {
        return LayoutPanel.CreateColumn()
            .With(t => fieldInfo.ForEach(p =>
                t.Row(p.Size + 1, SizeType.Absolute).ContentEnd(CreateField(p))))
            .Row().ContentEnd(new EmptyPanel())
            .Build();
    }

    private Control CreateField(FieldInfoUiAttribute fieldInfoAttribute)
    {
        return LayoutPanel.CreateRow(fieldInfoAttribute.Size, SizeType.Absolute)
            .Column(30).ContentEnd(FactoryElements.Label_11(fieldInfoAttribute.LabelText))
            .Column(70).ContentEnd(fieldInfoAttribute
                .GetContol(context)
                .OnErrorProvider(fieldInfoAttribute.PropertyName, context))
            .Column(20, SizeType.Absolute).ContentEnd(new EmptyPanel())
            .Build();
    }
}