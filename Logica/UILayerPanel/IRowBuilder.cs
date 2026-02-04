namespace Logica.UILayerPanel;

public interface IRowBuilder
{
    IColumnBuilder Column(float width = 100, SizeType sizeType = SizeType.Percent);
    IRowBuilder Content(Control content);
    IColumnBuilder ContentEnd(Control content);
    IColumnBuilder End();

    Control Build();
}