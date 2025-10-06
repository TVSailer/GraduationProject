using Logica;

public partial class AdvancedProfileForm : Form
{
    private readonly CreatingElements elementFactory;
    private readonly BaseStyle style;

    public AdvancedProfileForm()
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

public partial class AdvancedProfileForm : Form
{
    private void LoadMyProfileMenuStrip()
    {
        var labels = elementFactory.CreateListLabel(
            Attributes.Surname + ":",
            Attributes.Name + ":",
            Attributes.Patronymic + ":",
            Attributes.Gender + ":",
            Attributes.DateBirth + ":",
            Attributes.NumberPhone + ":",
            "");

        var labels2 = elementFactory.CreateListLabel(
            "Teregera",
            "Valerii",
            "Valentinovich",
            "Men",
            "30.11.2005",
            "+7 (989) 857-62-43");

        var buttons = elementFactory.CreateListButton(
            "Изменить пароль",
            "Редактировать профиль");

        var tableInfo = elementFactory.CreateTableLayoutPanel(
            new ColumnStyle[] {
                new ColumnStyle(SizeType.Percent, 100),
                new ColumnStyle(SizeType.Absolute, 200),
                new ColumnStyle(SizeType.Absolute, 200),
                new ColumnStyle(SizeType.Percent, 100)},
            new RowStyle[] {
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35)})
            .ControlsAdd(new Panel(), 0, 0)
            .ControlsAddByColumnOrRow(labels, 1, 0, false)
            .ControlsAddByColumnOrRow(labels2, 2, 0, false)
            .ControlsAdd(new Panel(), 3, 4);

        var tableButton = elementFactory.CreateTableLayoutPanel(
            new ColumnStyle[] {
                new ColumnStyle(SizeType.Percent, 100),
                new ColumnStyle(SizeType.Absolute, 140),
                new ColumnStyle(SizeType.Absolute, 130),
                new ColumnStyle(SizeType.Absolute, 130),
                new ColumnStyle(SizeType.Percent, 100)},
            new RowStyle[] {
                new RowStyle(SizeType.Absolute, 60),
                new RowStyle(SizeType.Percent, 100)})
            .ControlsAdd(new Panel(), 0, 0)
            .ControlsAddByColumnOrRow(buttons, 2, 0, true)
            .ControlsAdd(new Panel(), 4, 1);

        var tableMain = elementFactory.CreateTableLayoutPanel(
            new ColumnStyle[] { 
                new ColumnStyle(SizeType.Percent, 100) }, 
            new RowStyle[] { 
                new RowStyle(SizeType.Percent, 40), 
                new RowStyle(SizeType.Percent, 100)})
            .ControlsAdd(tableInfo, 0, 0)
            .ControlsAdd(tableButton, 0, 1);

        Controls.Add(tableMain);
    }
}

public partial class AdvancedProfileForm : Form
{
    private void LoadEventsMenuStrip()
    {

    }
}



public partial class AdvancedProfileForm : Form
{
   

}

public class ProfileFormStyle : BaseStyle
{
}

