using CSharpFunctionalExtensions;

namespace Domain.Entitys.ImagesEntity;

public class ImageEventEntity : Entity, IImage
{
    public string? Url { get; set; }
}
