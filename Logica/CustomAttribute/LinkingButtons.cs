namespace Logica.CustomAttribute
{
    public class LinkingButtonsAttribute<T> : Attribute
    {
        public string nameButton { get; private set; }

        public LinkingButtonsAttribute(string nameButton)
        {
            if (typeof(T).GetProperty(nameButton) == null)
                throw new ArgumentException();

            this.nameButton = nameButton;
        }
    }
}