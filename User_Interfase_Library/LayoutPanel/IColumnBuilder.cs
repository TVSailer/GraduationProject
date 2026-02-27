using System.Windows.Forms;
using User_Interface_Library.TableLayerPanel.ContentSelection;

namespace User_Interface_Library.LayoutPanel;

public interface IColumnBuilder
{
    IRowBuilder Row(float height = 100, SizeType sizeType = SizeType.Percent);
    IContentSelector<IRowBuilder> Content();
    IRowBuilder ContentEnd(Control content);
    IRowBuilder End();
    Control Build();
}