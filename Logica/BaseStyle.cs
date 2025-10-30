using ContentAlignment = System.Drawing.ContentAlignment;

namespace Logica
{
    public class BaseStyle : IDisposable
    {
        // Виртуальные свойства с значениями по умолчанию
        public virtual DockStyle DockStyle => DockStyle.Fill;
        public virtual Font Font => CreateFont("Times New Roman", 11);
        public virtual DateTimePickerFormat DateTimePickerFormat => DateTimePickerFormat.Short;
        public virtual ContentAlignment ContentAlignment => ContentAlignment.MiddleLeft;
        public virtual DataGridViewAutoSizeColumnsMode DataGridViewAutoSizeColumnsMode => DataGridViewAutoSizeColumnsMode.Fill;

        // Новые свойства для дополнительной гибкости
        public virtual Color BackColor => SystemColors.Control;
        public virtual Color ForeColor => SystemColors.ControlText;
        public virtual Color ButtonBackColor => SystemColors.ButtonFace;
        public virtual Color ButtonForeColor => SystemColors.ControlText;
        public virtual int ControlHeight => 25;
        public virtual int ButtonHeight => 30;
        public virtual int LabelWidth => 120;
        public virtual int TextBoxWidth => 200;
        public virtual Padding ControlPadding => new Padding(5);
        public virtual Padding FormPadding => new Padding(10);
        public virtual BorderStyle TextBoxBorderStyle => BorderStyle.FixedSingle;
        public virtual BorderStyle LabelBorderStyle => BorderStyle.None;
        public virtual FlatStyle ButtonFlatStyle => FlatStyle.Standard;

        // Стили для конкретных элементов
        public virtual Font TitleFont => CreateFont("Times New Roman", 14, FontStyle.Bold);
        public virtual Font HeaderFont => CreateFont("Times New Roman", 12, FontStyle.Bold);
        public virtual Font BoldFont => CreateFont("Times New Roman", 11, FontStyle.Bold);

        public virtual int LabelHeinght => 30;

        public virtual int TextBoxHeight => 30;

        private readonly List<Font> _createdFonts = new List<Font>();

        private Font CreateFont(string name, float size, FontStyle style = FontStyle.Regular)
        {
            var font = new Font(name, size, style);
            _createdFonts.Add(font);
            return font;
        }

        public void Dispose()
        {
            foreach (var font in _createdFonts)
                font?.Dispose();
        }
    }
}

