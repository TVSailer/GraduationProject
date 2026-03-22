using CSharpFunctionalExtensions;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public class ImageEventEntity : Entity, IImage
{
    [Image] public string? Url { get; set; }
}
