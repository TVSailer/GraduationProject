using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.Extension;

namespace Domain.Entitys;

public class EstimationEntity : Entity
{
    public string EstimationName { get; private set; }
    public int Estimation { get; private set; }

    private EstimationEntity() { }

    public EstimationEntity(Estimation estimation)
    {
        EstimationName = estimation.ToDescriptionString();
        Estimation = (int)estimation;
    }
}