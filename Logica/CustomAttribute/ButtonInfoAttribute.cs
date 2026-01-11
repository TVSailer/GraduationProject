
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.Lesson
{
    public class ButtonInfoAttribute : Attribute
    {
        public string Text { get; private set; }
        public string ButtonName { get; private set; }

        public ButtonInfoAttribute(string text, [CallerMemberName] string button = "")
        {
            Text = text;
            ButtonName = button;
        }

    }
}