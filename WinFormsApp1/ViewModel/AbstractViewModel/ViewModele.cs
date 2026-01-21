using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1;

namespace Admin.ViewModel.MovelView
{
    public abstract class ViewModele<TEntity> : PropertyChange, IViewModele<TEntity>
        where TEntity : Entity, new()
    {
        [ButtonInfoUI("Назад")] public ICommand OnBack { get; protected set; }

        public TEntity Entity { get; set; }

        public T TryValidProperty<T>(ref T field, T value, [CallerMemberName] string prop = "")
            => TryValidPropertyInfo(ref field, value, prop, prop);
        
        public T TryValidPropertyInfo<T>(ref T field, T value, string infoProperty, [CallerMemberName] string prop = "")
        {
            field = value;
            Validatoreg.TryValidProperty(value, prop, this, out string errorMessage);
            OnMassegeErrorProvider(errorMessage, infoProperty);
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

    }
}
