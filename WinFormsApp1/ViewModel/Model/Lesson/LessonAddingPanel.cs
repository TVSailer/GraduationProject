using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using MediatR;

namespace Admin.ViewModels.Lesson
{
    public class SaveCommandHandler<T, TEntity>(IMediator mediator, Repository<TEntity> repository, T instance) : IRequestHandler<SaveCommandRequest<T, TEntity>>
        where T : IViewModele<TEntity>
        where TEntity : Entity, new()
    {
        public Task Handle(SaveCommandRequest<T, TEntity> request, CancellationToken cancellationToken)
        {
            mediator.Send(new ValidationObjectRequest<T>(instance, obj => repository.Add(obj.Entity.GetEntity())), cancellationToken);
            return Task.CompletedTask;
        }
    }

    public class LessonAddingPanel : LessonData, IViewModel<LessonAddingPanel>
    {
        private readonly LessonsRepository lessonsRepository;
        private readonly IMediator mediator;

        public LessonAddingPanel(
            LessonsRepository lessonsRepository, 
            IMediator mediator,
            TeacherRepository teacherRepository, 
            LessonCategoryRepositroy lessonCategoryRepositroy) : base(teacherRepository, lessonCategoryRepositroy)
        {
            this.lessonsRepository = lessonsRepository;
            this.mediator = mediator;
        }
    }
}
