using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImgNewsEntity : Entity, IImage
{
    [Image] public string? Url { get; set; }
}

