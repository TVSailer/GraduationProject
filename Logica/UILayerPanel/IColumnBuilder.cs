namespace Logica.UILayerPanel;

public interface IColumnBuilder
{
    IRowBuilder Row(float height = 100, SizeType sizeType = SizeType.Percent);
    IColumnBuilder Content(Control content);
    IRowBuilder ContentEnd(Control? content);
    IRowBuilder End();

    Control Build();
}