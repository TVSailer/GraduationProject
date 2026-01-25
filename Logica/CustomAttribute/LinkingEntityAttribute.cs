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
}