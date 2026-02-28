using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel;

public interface IRowBuilder : IBuilder
{
    IColumnBuilder Column(float width = 100, SizeType sizeType = SizeType.Percent);
    IContentSelector<IColumnBuilder> Content();
    IColumnBuilder ContentEnd(Control? content);
    IColumnBuilder End();
}