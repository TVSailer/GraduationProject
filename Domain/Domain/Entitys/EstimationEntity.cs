using Domain.Enum;
using Domain.Extension;

namespace Domain.Entitys;

public class EstimationEntity
{
    public Estimation Id { get; private set; }
    public string EstimationName { get; private set; }
    public string EstimationDesctiption { get; private set; }

    private EstimationEntity() { }


    public EstimationEntity(Estimation estimation)
    {
        Id = estimation;
        EstimationName = estimation.ToString();
        EstimationDesctiption = estimation.ToDescriptionString();
    }
}