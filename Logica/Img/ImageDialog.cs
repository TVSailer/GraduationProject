using Logica.CustomAttribute;
using System.Windows.Forms;

namespace Logica.Img
{
    public class ImageDialog
    {
        public static string[] WorkWithImages(Action<string> actino, bool multiselect)
        {

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите изображения мероприятия";
                openFileDialog.Multiselect = multiselect;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (multiselect)
                        foreach (var fileName in openFileDialog.FileNames)
                            actino?.Invoke(fileName);
                    else actino?.Invoke(openFileDialog.FileName);
                }

                return openFileDialog.FileNames;
            }
        }
    }
}
