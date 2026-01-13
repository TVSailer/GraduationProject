using CSharpFunctionalExtensions;

namespace Admin.ViewModels.Lesson
{
    public class LinkingEntityAttribute : Attribute
    {
        public string NamePropertyEntity { get; private set; }

        public LinkingEntityAttribute(string nameProperty)
        {
            NamePropertyEntity = nameProperty;
        }
    }
}