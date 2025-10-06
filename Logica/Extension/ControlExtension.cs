namespace Logica
{
    public static class ControlExtension
    {
        public static string TextSQL(this Control control)
        {
            if (control is DateTimePicker)
            {
                var text = "'";
                foreach (var chare in control.Text)
                    text += chare == '.' ? '-' : chare;
                text += "'";
                return text;
            }

            return "'" + control.Text + "'";

        }
    }
}
