using System.ComponentModel;
using Admin.ViewModel.AbstractViewModel;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.UIModel;

public class ImageModule<TEntity>(FieldModelWithImages<TEntity> fieldModele) : IUIModel
    where TEntity : Entity, new()
{
    public readonly FieldModelWithImages<TEntity> Context = fieldModele;

    public Control CreateControl()
        => LayoutPanel.CreateColumn()
            .Row(50, SizeType.Absolute).ContentEnd(FactoryElements.Label_12("📷 Изображения:"))
            .Row().ContentEnd(FactoryElements.FlowLayoutPanel()
                .With(fp => Context.PropertyChanged += AddingImages(fp)))
            .Build();

    private PropertyChangedEventHandler AddingImages(FlowLayoutPanel fp)
    {
        return (obj, propCh) =>
        {
            if (propCh.PropertyName != nameof(Context.ListImgs)) return;

            fp.Controls.Clear();
            AddImages(fp);
        };
    }

    private void AddImages(FlowLayoutPanel fp)
    {
        Context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.PictureBox(url.Key)
            .With(i => i.MouseClick += (s, e) =>
            {
                Context.SelectedImg[url.Key] = !Context.SelectedImg[url.Key];
                i.BackColor = Context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
            })));
    }
}