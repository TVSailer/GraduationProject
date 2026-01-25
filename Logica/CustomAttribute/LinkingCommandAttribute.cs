namespace Admin.ViewModels.Lesson;

[AttributeUsage(AttributeTargets.Class)]
public class LinkingCommandAttribute : Attribute
{
    public string NameCommand { get; }

    public LinkingCommandAttribute(string nameCommand)
    {
        NameCommand = nameCommand;
    }
}