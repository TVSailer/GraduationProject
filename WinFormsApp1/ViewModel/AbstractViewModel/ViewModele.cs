using Admin.ViewModel.WordWithEntity;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using Logica;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Admin.ViewModel.MovelView
{
    public abstract class ViewModele<TEntity> : PropertyChange, IViewModele<TEntity>
        where TEntity : Entity, new()
    {
        [ButtonInfoUI("Назад")] public ICommand OnBack { get; protected set; }
        public GenericRepositoryEntity<TEntity> GenericRepositoryEntity { get; set; } = new();


        public ViewModele()
        {
            GenericRepositoryEntity.Initialize(this);
        }

        public T TryValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
        {
            field = value;
            Validatoreg.TryValidProperty(value, prop, this, out string errorMessage);
            OnMassegeErrorProvider(errorMessage, prop);
            OnPropertyChanged(prop);

            return value;
        }

        protected void TryValidObject(Action action)
        {
            if (Validatoreg.TryValidObject(this, out var results, false))
            {
                action.Invoke();
                OnBack.Execute(null);
            }
            else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
        }

        public void SetEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Initialize(object? value)
        {
            throw new NotImplementedException();
        }
    }
}
