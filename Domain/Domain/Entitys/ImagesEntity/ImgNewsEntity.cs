using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity.Base;
using Domain.ValidObject;

namespace Domain.Entitys.ImagesEntity;

public class ImageNewsEntity : Entity, IImage
{
    public string? Url { get; set; }

    private ImageNewsEntity() { }

    public ImageNewsEntity(ImageValidObject image)
    {
        Url = image.FileName;
    }
}

