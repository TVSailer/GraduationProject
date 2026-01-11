namespace Admin.ViewModels.Lesson
{
    public class FieldInfoViewModelAttribute : Attribute
    {
        public string NamePropertyEntity { get; private set; }

        public FieldInfoViewModelAttribute(string namePropertyEntiy)
        {
            NamePropertyEntity = namePropertyEntiy;
        }
    }
}