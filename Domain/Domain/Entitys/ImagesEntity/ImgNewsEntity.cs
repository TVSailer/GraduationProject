using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity.Base;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImageNewsEntity : Entity, IImage
{
    public string? Url { get; set; }
}

