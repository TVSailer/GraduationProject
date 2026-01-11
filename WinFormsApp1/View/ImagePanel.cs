using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.ComponentModel;
using WinFormsApp1.View;

public class ImagePanel<TEntity>
     where TEntity : Entity, new()
{
    public readonly ViewModelWithImages<TEntity> context;

    public ImagePanel(ViewModelWithImages<TEntity> viewModelImages)
    {
        context = viewModelImages;
    }

    public Control? Images()
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
            }
        };
    }

    private IEnumerable<KeyValuePair<string, bool>> AddImages(FlowLayoutPanel fp)
    {
        return context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.PictureBox(url.Key)
            .With(i => i.MouseClick += (s, e) =>
            {
                context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
                i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
            })));
    }
}

