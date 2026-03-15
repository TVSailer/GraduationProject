using DataAccess.PostgreSQL.Models;
using UserInterface.GenericEntity;
using UserInterface.Interface;

namespace Visitor.FieldData.Event;

public class EventDataUi : IDataUi<EventEntity>, IDataWithImgUi
{
    public EventEntity Entity
    {
        get => field ?? throw new ArgumentNullException();
        set
        {
            EntityId = value.Id;
            RepositoryImgEntity.SetData(value.Imgs.Select(i => i.Url).ToArray());
            field = value;
        }
    }

    public long EntityId { get; set; }
    public RepositoryImgEntity RepositoryImgEntity { get; set; } = new();
}