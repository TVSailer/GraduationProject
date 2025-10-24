using Logica;

public partial class ViewVisitor : Form
{
    private void LoadMyProfileMenuStrip()
    {
        Controls.Clear();

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

        var tableInfo = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
                new ColumnStyle(SizeType.Percent, 100),
                new ColumnStyle(SizeType.Absolute, 200),
                new ColumnStyle(SizeType.Absolute, 200),
                new ColumnStyle(SizeType.Percent, 100))
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35),
                new RowStyle(SizeType.Absolute, 35))
            .ControlsAdd(new Panel(), 0, 0)
            .ControlsAddByColumnOrRow(labels, 1, 0, false)
            .ControlsAddByColumnOrRow(labels2, 2, 0, false)
            .ControlsAdd(new Panel(), 3, 4);

        var tableButton = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
                new ColumnStyle(SizeType.Percent, 100),
                new ColumnStyle(SizeType.Absolute, 140),
                new ColumnStyle(SizeType.Absolute, 130),
                new ColumnStyle(SizeType.Absolute, 130),
                new ColumnStyle(SizeType.Percent, 100))
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 60),
                new RowStyle(SizeType.Percent, 100))
            .ControlsAdd(new Panel(), 0, 0)
            .ControlsAddByColumnOrRow(buttons, 2, 0, true)
            .ControlsAdd(new Panel(), 4, 1);

        var tableMain = elementFactory.CreateTableLayoutPanel()
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 25), 
                new RowStyle(SizeType.Percent, 40), 
                new RowStyle(SizeType.Percent, 100))
            .ControlsAdd(menuStrip, 0, 0)
            .ControlsAdd(tableInfo, 0, 1)
            .ControlsAdd(tableButton, 0, 2);

        Controls.Add(tableMain);
    }
}
