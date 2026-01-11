using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public abstract class ViewModel<TEntity> : PropertyChange
        where TEntity : Entity, new()
    {
        public Action<TEntity> OnGetEntity;
        public Action<TEntity> OnSetEntiy;

        private Dictionary<FieldInfoViewModelAttribute, PropertyInfo> fieldInfoAttributes = new();

        protected TEntity Entity
        {
            get
            {
                if (field is null) throw new ArgumentNullException();
                OnGetEntity?.Invoke(field);

                return field;
            }
            set
            {
                OnSetEntiy?.Invoke(value);

                field = value;

                fieldInfoAttributes.ForEach(i =>
                {
                    var rez = typeof(TEntity)
                    .GetProperty(i.Key.NamePropertyEntity)
                    .GetValue(Entity);

                    i.Value.SetValue(this, rez);
                });

            }
        } = new();

        [ButtonInfo("Назад")] public ICommand OnBack { get; protected set; }
        [ButtonInfo("Сохранить")] public ICommand OnSave { get; protected set; }
        [ButtonInfo("Обновить")] public ICommand OnUpdate { get; protected set; }
        [ButtonInfo("Удалить")] public ICommand OnDelete { get; protected set; }

        public T Set<T>(T value, [CallerMemberName] string prop = "")
        {
            if (value is null) throw new ArgumentNullException();

            if (!Validatoreg.TryValidProperty(value, prop, this, out string errorMessage))
            {
                OnMassegeErrorProvider(errorMessage, prop);
                return value;
            }

            //var entityProp = typeof(TEntity).GetProperty(propEntity) ?? throw new ArgumentNullException();
            //entityProp.SetValue(Entity, value);

            OnMassegeErrorProvider("", prop);
            OnPropertyChanged(prop);

            return value;
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

            GetType().GetProperties()
                .ForEach(p => p.GetCustomAttributes().ForEach(a =>
                {
                    if (a is FieldInfoViewModelAttribute obj)
                        fieldInfoAttributes.Add(obj, p);
                }));
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


        public void SetData(TEntity value)
        {
            Entity = value;
        }

        public List<TAttribute?> GetPropertyInfo<TAttribute>() 
            where TAttribute : Attribute
        {
            return GetType().GetProperties()
                .Select(p => p.GetCustomAttribute<TAttribute>())
                .Where(at => at != null)
                .ToList() ?? throw new ArgumentNullException();
        }
    }
}
