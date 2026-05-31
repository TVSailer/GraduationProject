using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity.Base;
using Domain.ValidObject;

namespace Domain.Entitys.ImagesEntity;

public class ImageLessonEntity : Entity, IImage
{
    public string Url { get; set; }

    private ImageLessonEntity() { }

    public ImageLessonEntity(ImageValidObject image)
    {
        Url = image.FileName;
    }
}