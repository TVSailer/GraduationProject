using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity.Base;
using Domain.ValidObject;

namespace Domain.Entitys.ImagesEntity;

public class ImageEventEntity : Entity, IImage
{
    public string Url { get; set; }
    private ImageEventEntity() {}

    public ImageEventEntity(ImageValidObject image)
    {
        Url = image.FileName;
    }
}
