public class ButtonInfo
{
    public string DataMember { get; private set; }
    public string Text { get; private set; }

    public ButtonInfo(string text, string dataMember)
    {
        Text = text;
        DataMember = dataMember;
    }
}

