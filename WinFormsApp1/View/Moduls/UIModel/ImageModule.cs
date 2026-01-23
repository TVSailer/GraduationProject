using Admin.View.Moduls.UIModel;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.ComponentModel;

public class ImageModule<TEntity> : IUIModel
    where TEntity : Entity, new()
{
    public readonly ViewModelWithImages<TEntity> context;

    public ImageModule(IViewModele<TEntity> viewModele)
    {
        if (viewModele is ViewModelWithImages<TEntity> obj2)
            context = obj2;
    }

    public Control? CreateControl()
        => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsolute(
                FactoryElements.Label_12("📷 Изображения:"), 50)
            .ControlAddIsRowsPercent(
                FactoryElements.FlowLayoutPanel()
                    .With(fp => AddImages(fp))
                    .With(fp => context.PropertyChanged += AddingImages(fp)));

    private PropertyChangedEventHandler AddingImages(FlowLayoutPanel fp)
    {
        return (obj, propCh) =>
        {
            if (propCh.PropertyName == nameof(context.OnAddingImg) ||
                propCh.PropertyName == nameof(context.OnDeletingImg))
            {
                fp.Controls.Clear();
                AddImages(fp);
            }
        };
    }

    private void AddImages(FlowLayoutPanel fp)
    {
        context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.PictureBox(url.Key)
            .With(i => i.MouseClick += (s, e) =>
            {
                context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
                i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
            })));
    }
}