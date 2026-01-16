
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.Lesson
{
    public class FieldInfoSerchAttribute : Attribute
    {
        public string Text { get; private set; }
        public string NameProperty { get; private set; }

        public FieldInfoSerchAttribute(string text, [CallerMemberName] string prop = "")
        {
            Text = text;
            NameProperty = prop;
        }
    }
}