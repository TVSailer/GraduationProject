using Logica;

public partial class ViewVisitor : Form
{
    private readonly CreatingElements elementFactory;
    private readonly BaseStyle style;

    public ViewVisitor()
    {
        style = new ProfileFormStyle();
        elementFactory = new CreatingElements(style);
        InitializeForm();
        CreateMenuStrip();
    }

    private void InitializeForm()
    {
        this.Text = "";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.WindowState = FormWindowState.Maximized;
        this.Padding = style.FormPadding;
        this.BackColor = style.BackColor;
    }

    private void CreateMenuStrip()
    {
        var menuStrip = elementFactory.CreateMenuStrip(
            elementFactory.CreateToolStripMenu(
                "Меню", 
                new StripMenuItem("Мой профиль", LoadMyProfileMenuStrip),
                new StripMenuItem("Мероприятия", null),
                new StripMenuItem("Новости", LoadNewsMenuStrip)),
            elementFactory.CreateToolStripMenu(
                "Действия",
                new StripMenuItem("Закрыть", Close)));

        Controls.Add(menuStrip);
    }
}

public class ProfileFormStyle : BaseStyle
{
}
