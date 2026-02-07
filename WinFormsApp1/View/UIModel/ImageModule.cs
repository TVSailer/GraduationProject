using System.ComponentModel;
using Admin.View.Moduls.UIModel;
using Admin.ViewModel.AbstractViewModel;
using CSharpFunctionalExtensions;
using Logica;
using Logica.UILayerPanel;

public class ImageModule<TEntity> : IUIModel
    where TEntity : Entity, new()
{
    public readonly ViewModelWithImages<TEntity> context;

    public ImageModule(ViewModelWithImages<TEntity> viewModele)
    {
        context = viewModele;
    }

    public Control? CreateControl()
    => Layout.CreateColumn()
        .Row(50, SizeType.Absolute).ContentEnd(FactoryElements.Label_12("📷 Изображения:"))
        .Row().ContentEnd(FactoryElements.FlowLayoutPanel()
                    .With(fp => context.PropertyChanged += AddingImages(fp)))
        .Build();

    private PropertyChangedEventHandler AddingImages(FlowLayoutPanel fp)
    {
        return (obj, propCh) =>
        {
            if (propCh.PropertyName != nameof(context.ListImgs)) return;

            fp.Controls.Clear();
            AddImages(fp);
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