using Logica;

public partial class ViewVisitor : Form
{
    private readonly CreatingElements elementFactory;
    private readonly BaseStyle style;
    private MenuStrip menuStrip;
    private Panel displayItems;
    public ViewVisitor()
    {
        style = new VisitorViewStyle();
        elementFactory = new CreatingElements(style);
        InitializeForm();
        CreateMenuStrip();
    }

    private void InitializeForm()
    {
        Text = "";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        Padding = style.FormPadding;
        BackColor = style.BackColor;
    }

    private void CreateMenuStrip()
    {
        menuStrip = elementFactory.CreateMenuStrip(
            elementFactory.CreateToolStripMenu(
                Attributes.Menu, 
                new StripMenuItem(Attributes.MyProfile, LoadMyProfileMenuStrip),
                new StripMenuItem(Attributes.Events, LoadEventsMenuStrip),
                new StripMenuItem(Attributes.News, LoadNewsMenuStrip),
                new StripMenuItem(Attributes.Lessons, LoadLessonsMenuStrip),
                new StripMenuItem(Attributes.Visitoring, null)),
            elementFactory.CreateToolStripMenu(
                Attributes.Action,
                new StripMenuItem(Attributes.Close, Close),
                new StripMenuItem(Attributes.Update, null)));

        Controls.Add(menuStrip);
    }

    private void DisplayItems<T>(T[] items, Func<T, int, TableLayoutPanel> func) 
    {
        displayItems.Controls.Clear();

        int yPosition = 10;

        foreach (var eventItem in items)
        {
            var eventCard = func?.Invoke(eventItem, yPosition);
            displayItems.Controls.Add(eventCard);
            yPosition += eventCard.Height + 10;
        }

        displayItems.Height = yPosition;
    }
}
