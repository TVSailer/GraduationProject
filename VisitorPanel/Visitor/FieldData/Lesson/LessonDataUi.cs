using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.GenericEntity;
using UserInterface.Interface;

namespace Visitor.FieldData.Lesson;

public class LessonDataUi : IDataUi<LessonEntity>, IDataWithImgUi
{
    public LessonEntity Entity
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