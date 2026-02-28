using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel;

public interface IColumnBuilder : IBuilder
{
    IRowBuilder Row(float height = 100, SizeType sizeType = SizeType.Percent);
    IContentSelector<IRowBuilder> Content();
    IRowBuilder ContentEnd(Control content);
    IRowBuilder End();
}