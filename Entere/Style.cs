using Logica;

namespace Entere
{
    class Style : BaseStyle
    {
    }
// Стандартный стиль
    public class StandardStyle : BaseStyle
    {
        // Можно переопределить любые свойства
    }

    // Стиль для форм ввода данных
    public class FormStyle : BaseStyle
    {
        public override DockStyle DockStyle => DockStyle.Top;
        public override int ControlHeight => 30;
        public override int LabelWidth => 150;
        public override int TextBoxWidth => 250;
        public override ContentAlignment ContentAlignment => ContentAlignment.MiddleRight;
    }

    // Стиль для отображения данных (только чтение)
    public class DisplayStyle : BaseStyle
    {
        public override Color BackColor => Color.WhiteSmoke;
        public override BorderStyle TextBoxBorderStyle => BorderStyle.FixedSingle;
        public override BorderStyle LabelBorderStyle => BorderStyle.FixedSingle;
        public override Action<TextBox> ApplyTextBoxStyle => (textBox) =>
        {
            base.ApplyTextBoxStyle(textBox);
            textBox.ReadOnly = true;
            textBox.BackColor = Color.WhiteSmoke;
        };
    }

    // Стиль для панели инструментов
    public class ToolbarStyle : BaseStyle
    {
        public override DockStyle DockStyle => DockStyle.Top;
        public override Font Font => new Font("Times New Roman", 10);
        public override int ButtonHeight => 35;
        public override Color ButtonBackColor => Color.LightSteelBlue;
        public override FlatStyle ButtonFlatStyle => FlatStyle.Flat;
    }

    // Стиль для диалоговых окон
    public class DialogStyle : BaseStyle
    {
        public override DockStyle DockStyle => DockStyle.None;
        public override int ControlHeight => 28;
        public override int ButtonHeight => 32;
        public override Padding FormPadding => new Padding(15);
    }
}
