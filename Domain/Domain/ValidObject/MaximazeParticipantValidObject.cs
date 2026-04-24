using Domain.Exception;

namespace Domain.ValidObject;

public class MaximazeParticipantValidObject
{
    public int Value { get; }

    public MaximazeParticipantValidObject(int value)
    {
        if (value < 1) throw new ValidObjectException("Кол-во поситителей не может быть меньше 1");
        if (value > 50) throw new ValidObjectException("Кол-во поситителей не может быть больше 50");

        Value = value;
    }
}