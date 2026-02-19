using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using Logica.Extension;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class FieldLayoutPanel
{
    private readonly object context;
    private List<FieldInfoUiAttribute> fieldInfo => context.GetType().GetAttributes<FieldInfoUiAttribute>();

    public FieldLayoutPanel(object context)
    {
        this.context = context;
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
            .Column(70).ContentEnd(fieldInfoAttribute.GetControl(context))
            .Column(20, SizeType.Absolute).ContentEnd(new EmptyPanel())
            .Build();
    }
}