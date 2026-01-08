using Logica;
using System.Windows.Input;

namespace Admin.ViewModel.NotifuPropertyViewModel
{
    public abstract class NotifyPropertyImagesViewModel : NotifyPropertyViewModel
    {
        public Dictionary<string, bool> SelectedImg { get; private set; } = new();

        public ICommand OnAddingImg { get; protected set; }
        public ICommand OnDeletingImg { get; protected set; }

        public NotifyPropertyImagesViewModel()
        {
            OnAddingImg = new MainCommand(
            _ =>
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Выберите изображения мероприятия";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var fileName in openFileDialog.FileNames)
                        {
                            if (!SelectedImg.ContainsKey(fileName))
                                SelectedImg.Add(fileName, false);
                        }
                    }
                }

                OnPropertyChanged(nameof(OnAddingImg));
            });

            OnDeletingImg = new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
                OnPropertyChanged(nameof(OnDeletingImg));
            });
        }
    }
}
