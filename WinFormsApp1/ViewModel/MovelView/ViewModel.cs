using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public abstract class ViewModel<TEntity> : PropertyChange, IViewModel<TEntity>
        where TEntity : Entity
    {
        
        protected TEntity Entity
        {
            get
            {
                if (field is null) throw new ArgumentNullException();
                return field;
            }
            set;
        }

        [ButtonInfo("Назад")] public ICommand OnBack { get; protected set; }
        [ButtonInfo("Сохранить")] public ICommand OnSave { get; protected set; }
        [ButtonInfo("Обновить")] public ICommand OnUpdate { get; protected set; }
        [ButtonInfo("Удалить")] public ICommand OnDelete { get; protected set; }

        public void Set<T>(ref T file, T value, [CallerMemberName] string prop = "")
        {
            if (value is null) throw new ArgumentNullException();

            file = value;

            if (!Validatoreg.TryValidProperty(file, prop, this, out string errorMessage))
            {
                OnMassegeErrorProvider(errorMessage, prop);
                return;
            }

            Entity.GetType()
                .GEt

            OnMassegeErrorProvider("", prop);
            OnPropertyChanged(prop);
        }

        public ViewModel() { }

        public ViewModel(Repository<TEntity> repository)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(actionSave));

            OnUpdate = new MainCommand(
                _ => TryValidObject(() => repository.Update(Entity.Id, Entity)));

            OnDelete = new MainCommand(
                _ =>
                {
                    repository.Delete(Entity);
                    OnBack.Execute(this);
                });
        }

        private void TryValidObject(Action action)
        {
            if (Validatoreg.TryValidObject(this, out var results, false))
            {
                action.Invoke();
                OnBack.Execute(null);
            }
            else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
        }

        protected abstract Action actionSave { get; set; }

        public abstract IViewModel<TEntity> Initialize(object value);
        public abstract void SetData(TEntity value);
    }
}
