using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventSerch : SerchManagment<EventEntity>
    {
        public EventSerch(Repository<EventEntity> repository) : base(repository)
        {
        }

        public override Func<List<EventEntity>, List<EventEntity>> OnSerhFunk { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
        public override Action OnClearSerchFunk { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
    }
}
