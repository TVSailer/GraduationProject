using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ImagesEntity;

public interface IImage
{
    [Image] public string? Url { get; set; }
}
