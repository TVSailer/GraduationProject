namespace Admin.ViewModels.Lesson
{
    public class LinkingButtons : Attribute
    {
        public string[] nameButton { get; private set; }

        public LinkingButtons(Type type, params string[] nameButton)
        {
            for (int i = 0; i < nameButton.Length; i++)
                if (type.GetProperty(nameButton[i]) == null)
                    throw new ArgumentException();
        }
    }
}