using DataAccess.PostgreSQL;
using Domain.Entitys;
using Domain.Entitys.ComplexType;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.ImageService.BaseServiceImage;
using Domain.ValidObject;
using Day = Domain.Enum.Day;

namespace Admin;

public class TestData 
{
    public IEnumerable<string> _images { get; set; } = [];

    public TestData(ApplicationDbContext dbContext, IRepository<AuthEntity> repositoryA, IImageService imageService)
    {
        LoadData(dbContext, repositoryA, imageService);
    }

    public void LoadData(ApplicationDbContext dbContext, IRepository<AuthEntity> repositoryA, IImageService imageService)
    {
        //dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();


        //imageService.BindingImages(this, nameof(_images));
        //imageService.AddImage();
        //var images = imageService.UpdateImagesFromCloudDisk().Result;


        var category = new CategoryEntity(new CategoryValidObject("Развлечение"));

        dbContext.AddRange(
            new EstimationEntity(Estimation.Badly),
            new EstimationEntity(Estimation.Moderately),
            new EstimationEntity(Estimation.Satisfactory),
            new EstimationEntity(Estimation.Good),
            new EstimationEntity(Estimation.Excellent)
            );

        dbContext.AddRange(category,
            new CategoryEntity(new CategoryValidObject("Туризм")),
            new CategoryEntity(new CategoryValidObject("IT")));


        dbContext.AddRange(
            new UserRoleEntity(UserRole.Admin),
            new UserRoleEntity(UserRole.Teacher),
            new UserRoleEntity(UserRole.Visitor));

        //for (int i = 0; i < 10; i++)
        //{
        //    dbContext.Add(new NewsEntity(
        //        new TitleValidObject($"Название{i}"),
        //        new DescriptionValidObject($"Контент{i} Описание{i} Описание{i} Описание{i} Описание{i}"),
        //        DateOnly.Parse("30.11.2026"),
        //        category,
        //        new AuthorValidObject($"Автор{i}"),
        //        images
        //    ));

        //    dbContext.Add(
        //        new EventEntity(
        //            new TitleValidObject($"Название{i}"),
        //            new ImageValidObject(images.ToList()[0]),
        //            new DescriptionValidObject($"Описание{i} Описание{i} Описание{i} Описание{i} Описание{i}"),
        //            new LocationValidObject($"Локация{i}"),
        //            new HttpLinkValidObject($"https://k{i}"),
        //            new OrganizerValidObject($"Огранизатор{i}"),
        //            new EventEntitySchedule(
        //                TimeOnly.Parse("11:00"),
        //                TimeOnly.Parse("12:00"),
        //                DateOnly.Parse("30.11.2027")),
        //            category,
        //            images
        //        ));

        //    var authTeacher = new AuthEntity(
        //        new LoginValidObject($"Фамилия{i}"),
        //        new PasswordValidObject(repositoryA.Get().Select(a => a.Password).ToArray()),
        //        UserRole.Teacher
        //    );

        //    var authVisitor = new AuthEntity(
        //        new LoginValidObject($"Фамилия{i}"),
        //        new PasswordValidObject(repositoryA.Get().Select(a => a.Password).ToArray()),
        //        UserRole.Visitor
        //    );

        //    dbContext.AddRange(authVisitor, authTeacher);

        //    var teacher = new TeacherEntity(
        //        new ImageValidObject(images.ToList()[0]),
        //        new NameValidObject($"Имя{i}"),
        //        new SurnameValidObject($"Фамилия{i}"),
        //        new PatronymicValidObject($"Отчество{i}"),
        //        new DateBirthTeacherValidObject(DateOnly.Parse("30.11.2005")),
        //        new NumberPhoneValidObject("89898342334"),
        //        authTeacher
        //    );

        //    dbContext.Add(teacher);

        //    var lesson = new LessonEntity(
        //        new TitleValidObject($"Название{i}"),
        //        new DescriptionValidObject($"Описание{i} Описание{i} Описание{i} Описание{i} Описание{i}"),
        //        new LocationValidObject($"Локация{i}"),
        //        new MaximazeParticipantValidObject(i + 1),
        //        category,
        //        teacher,
        //        [
        //            new LessonScheduleEntity(
        //                TimeOnly.Parse("11:00"),
        //                TimeOnly.Parse("12:00"),
        //                Day.Friday),
        //            new LessonScheduleEntity(
        //                TimeOnly.Parse("11:00"),
        //                TimeOnly.Parse("12:00"),
        //                Day.Saturday),
        //            new LessonScheduleEntity(
        //                TimeOnly.Parse("11:00"),
        //                TimeOnly.Parse("12:00"),
        //                Day.Tuesday),
        //        ],
        //        images
        //    );

        //    dbContext.Add(lesson);

        //    var visitor = new VisitorEntity(
        //        new ImageValidObject(images.ToList()[0]),
        //        new NameValidObject($"Имя{i}"),
        //        new SurnameValidObject($"Фамилия{i}"),
        //        new PatronymicValidObject($"Отчество{i}"),
        //        new DateBirthVisitorValidObject(DateOnly.Parse("30.11.2005")),
        //        new NumberPhoneValidObject("89898342334"),
        //        authVisitor
        //    );

        //    visitor.AddLesson(lesson);

        //    dbContext.Add(new ReviewEntity(Estimation.Good, new CommentValidObject("норм норм норм норм норпм"), visitor, lesson));
        //    dbContext.AddRange(visitor);
        //}
        
        dbContext.SaveChanges();
    }
}

