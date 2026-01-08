using Admin.ViewModel.NotifuPropertyViewModel;
using Logica;
using System.ComponentModel;

namespace Admin.View.ImagePanel
{
    public class ImagPanel : IImagePanel
    {
        public readonly NotifyPropertyImagesViewModel context;

        public ImagPanel(NotifyPropertyImagesViewModel notify)
        {
            context = notify;
        }

        public Control? CreateImagePanel()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(
                FactoryElements.Label_12("📷 Изображения:"), 50)
            .ControlAddIsRowsPercentV2(
                FactoryElements.FlowLayoutPanel()
                .With(fp => AddImages(fp))
                .With(fp => context.PropertyChanged += AddingImages(fp)), 10);

        private PropertyChangedEventHandler AddingImages(FlowLayoutPanel fp)
        {
            return (obj, propCh) =>
            {
            if (propCh.PropertyName == nameof(context.OnAddingImg) || propCh.PropertyName == nameof(context.OnDeletingImg))
            {
                fp.Controls.Clear();
                AddImages(fp);
            }};
        }

        private IEnumerable<KeyValuePair<string, bool>> AddImages(FlowLayoutPanel fp)
        {
            return context.SelectedImg.ForEach(url => AddImage(fp, url));
        }

        private void AddImage(FlowLayoutPanel fp, KeyValuePair<string, bool> url)
        {
            fp.Controls.Add(FactoryElements.PictureBox(url.Key)
                .With(i => i.MouseClick += MouseClick(url, i)));
        }

        private MouseEventHandler MouseClick(KeyValuePair<string, bool> url, PictureBox i)
        {
            return (s, e) =>
            {
                context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
                i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
            };
        }
    }
}

