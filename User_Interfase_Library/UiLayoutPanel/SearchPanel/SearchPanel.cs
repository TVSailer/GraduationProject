using System.Windows.Forms;
using Extension_Func_Library;
using UserInterface.Attribute;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;

namespace UserInterface.UiLayoutPanel.SearchPanel;

public sealed class SearchPanel : Panel
{
    private readonly List<FieldInfoUiAttribute> _fieldInfos;
    public readonly ISearchEntity Context;

    public SearchPanel(ISearchEntity context)
    {
        BorderStyle = BorderStyle.FixedSingle;
        Dock = DockStyle.Fill;

        Context = context;
        _fieldInfos = context.GetField().GetType().GetAttributes<FieldInfoUiAttribute>();

        Initialize();
    }

    private void Initialize()
        => Controls.Add(
            new BuilderLayoutPanel().CreateColumn()
                .With(t => _fieldInfos
                    .ForEach(fi => t
                        .Row(60, SizeType.Absolute)
                        .Column(300, SizeType.Absolute).ContentEnd(FactoryElements.Label_11($"{fi.LabelText}: "))
                        .Column(10).ContentEnd(fi.GetControl(Context.GetField()))
                        .End()))
                .Row().ContentEnd(new EmptyPanel())
                .Row(60, SizeType.Absolute).ContentEnd(new CustomButton("Очистить поиск").CommandClick(() => Context.OnClearSearch()))
                .Build());
}