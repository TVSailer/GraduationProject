using DataAccess.Postgres.Models;
using Logica;
using Teacher.Presents;

namespace Teacher.Forms.Dates
{
    class FormAddingDateAttendance : Form
    {
        private const int WIDHT = 400;
        private const int HEINGT = 325;
        public BaseCreatingElements CreatingElements { get; set; }

        public FormAddingDateAttendance(DatePresent present, VisitorEntity[] visitors, DataGridView gridView)
        {
            CreatingElements = new CreatingElements(new Style());

            var checkedListBox = CreatingElements.CreateCheckedListBox(visitors);
            checkedListBox.ItemCheck += (send, e)
                =>
            {
                if (e.NewValue == CheckState.Checked)
                    present.Visitors.Add(visitors[e.Index]);
                else present.Visitors.Remove(visitors[e.Index]);
            };

            var date = CreatingElements.CreateDateTimePicker(Attributes.Date);
            date.TextChanged += (send, e) 
                => present.Date = date.Text;

            var labelDate = CreatingElements.CreateLabel(Attributes.Date);

            var listButton = CreatingElements.CreateListButton(
                Attributes.Add,
                Attributes.Close);

            listButton.SearchByParameter(Attributes.Close).Click += (send, e) 
                => Close();
            listButton.SearchByParameter(Attributes.Add).Click += (send, e)
                => present.OnAdd(ref gridView);


            var table = CreatingElements.CreateTableLayoutPanel(2, 30, 160, 30)
                .ControlsAdd(labelDate, 0, 0)
                .ControlsAdd(date, 1, 0)
                .ControlsAdd(checkedListBox, 0, 1, 3, 1)
                .ControlsAddByColumnOrRow(listButton, 0, 3, true);

            Controls.Add(table);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Size = new Size(WIDHT, HEINGT);
            Text = Attributes.AddDate;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
