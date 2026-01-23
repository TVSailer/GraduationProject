
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.Lesson
{
    public class ButtonInfoUIAttribute : Attribute
    {
        public string Text { get; private set; }
        public string ButtonName { get; private set; }

        public ButtonInfoUIAttribute(string text, [CallerMemberName] string button = "")
        {
            Text = text;
            ButtonName = button;
        }

    }
}