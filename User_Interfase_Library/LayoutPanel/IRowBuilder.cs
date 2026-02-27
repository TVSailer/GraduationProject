using System.Windows.Forms;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.TableLayerPanel.ContentSelection;

namespace User_Interface_Library.LayoutPanel;

public interface IRowBuilder
{
    IColumnBuilder Column(float width = 100, SizeType sizeType = SizeType.Percent);
    IContentSelector<IColumnBuilder> Content();
    IColumnBuilder ContentEnd(Control? content);
    IColumnBuilder End();
    Control Build();
}