using System.Windows.Input;

namespace Admin.ViewModels.Lesson
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LinkingEntityAttribute : Attribute
    {
        public string NamePropertyEntity { get; private set; }

        public LinkingEntityAttribute(string nameProperty)
        {
            NamePropertyEntity = nameProperty;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class LinkingCommandAttribute : Attribute
    {
        public string NameCommand { get; }

        public LinkingCommandAttribute(string nameCommand)
        {
            // typeof(T)
            //     .GetProperties()
            //     .Where(p => p.PropertyType.Equals(typeof(ICommand)))
            //     .First(p => p.Name.Equals(nameCommand));

            NameCommand = nameCommand;
        }
    }
}