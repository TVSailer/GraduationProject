
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Admin.ViewModels.Lesson
{
    public class FieldInfoUIAttribute : Attribute
    {
        public string Text { get; private set; }
        public bool Multiline { get; private set; }
        public bool ReadOnly { get; private set; }
        public string PlaceholderText { get; private set; }
        public int Size { get; private set; }
        public string NameProperty { get; private set; }

        public FieldInfoUIAttribute(string text, string placeholderText = "", bool multiline = false, bool readOnly = false, int size = 54, [CallerMemberName] string prop = "")
        {
            Text = text;
            PlaceholderText = placeholderText;
            ReadOnly = readOnly;
            Multiline = multiline;
            Size = size;
            NameProperty = prop;
        }
    }
}