using ContentAlignment = System.Drawing.ContentAlignment;

namespace Logica
{
    public static class Style
    {
        // Виртуальные свойства с значениями по умолчанию
        public static DockStyle DockStyle => DockStyle.Fill;
        public static Font Font => CreateFont("Times New Roman", 11);
        public static DateTimePickerFormat DateTimePickerFormat => DateTimePickerFormat.Short;
        public static ContentAlignment ContentAlignment => ContentAlignment.MiddleLeft;
        public static DataGridViewAutoSizeColumnsMode DataGridViewAutoSizeColumnsMode => DataGridViewAutoSizeColumnsMode.Fill;

        // Новые свойства для дополнительной гибкости
        public static Color BackColor => SystemColors.Control;
        public static Color ForeColor => SystemColors.ControlText;
        public static Color ButtonBackColor => SystemColors.ButtonFace;
        public static Color ButtonForeColor => SystemColors.ControlText;
        public static int ControlHeight => 25;
        public static int ButtonHeight => 30;
        public static int LabelWidth => 120;
        public static int TextBoxWidth => 200;
        public static Padding ControlPadding => new Padding(5);
        public static Padding FormPadding => new Padding(10);
        public static BorderStyle TextBoxBorderStyle => BorderStyle.FixedSingle;
        public static BorderStyle LabelBorderStyle => BorderStyle.None;
        public static FlatStyle ButtonFlatStyle => FlatStyle.Standard;

        // Стили для конкретных элементов
        public static Font TitleFont => CreateFont("Times New Roman", 14, FontStyle.Bold);
        public static Font HeaderFont => CreateFont("Times New Roman", 12, FontStyle.Bold);
        public static Font BoldFont => CreateFont("Times New Roman", 11, FontStyle.Bold);

        public static int LabelHeinght => 30;

        public static int TextBoxHeight => 30;

        public static Font CreateFont(string name, float size, FontStyle style = FontStyle.Regular)
            => new Font(name, size, style);
    }
}

