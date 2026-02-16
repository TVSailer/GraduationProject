using System.ComponentModel;
using Admin.ViewModel.AbstractViewModel;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.UIModel;

public class ImageLayoutPanel<TEntity>
    where TEntity : Entity, new()
{
    public readonly FieldModelWithImages<TEntity> Context;

    public ImageLayoutPanel(FieldModelWithImages<TEntity> context)
    {
        Context = context;
    }

    public Control CreateControl()
        => LayoutPanel.CreateColumn()
            .Row(50, SizeType.Absolute).ContentEnd(FactoryElements.Label_12("📷 Изображения:"))
            .Row().ContentEnd(FactoryElements.FlowLayoutPanel()
                .With(f => AddImages(f))
                .With(f => Context.PropertyChanged += AddingImages(f)))
            .Build();

    private PropertyChangedEventHandler AddingImages(FlowLayoutPanel f)
    {
        return (obj, propCh) =>
        {
            if (propCh.PropertyName != nameof(Context.ListImgs)) return;

            f.Controls.Clear();
            AddImages(f);
        };
    }

    private void AddImages(FlowLayoutPanel f)
    {
        Context.SelectedImg.ForEach(url => f.Controls.Add(FactoryElements.PictureBox(url.Key)
            .With(i => i.MouseClick += (s, e) =>
            {
                Context.SelectedImg[url.Key] = !Context.SelectedImg[url.Key];
                i.BackColor = Context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
            })));
    }
}