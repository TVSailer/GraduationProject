using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity.Base;

namespace Domain.Entitys.ImagesEntity;

public class ImageLessonEntity : Entity, IImage
{
    public string Url { get; set; }
}