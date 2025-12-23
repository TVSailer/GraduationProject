using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using Logica.DI;
using Logica.Massage;
using Logica.Message;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View.Teachers;

public abstract class TeacherDataViewModel : INotifyPropertyChanged, IMessageErrorProvider
{
    public ICommand OnBack { get; protected set; }
    public ICommand OnSave { get; protected set; }
    public ICommand OnAddingImg { get; protected set; }
    public ICommand OnDeletingImg { get; protected set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event ErrorMessegePropertyHandler? ErrorMassegeProvider;

    private bool isSave = false;

    private string name = "";
    private string surname = "";
    private string patronymic = "";
    private string dateBirth = "";
    private string numberPhone = "";
    private string urlFaceImg = "D:\\Документы\\Projects_CSharp\\GraduationProject\\Logica\\Img\\NoImg.png";

    private List<LessonEntity>? lessons = new();

    [Required(ErrorMessage = "Данное поле не может быть пустым!")]
    public string Name
    {
        get => name;
        set => Set(ref name, value, null);
    }

    [Required(ErrorMessage = "Данное поле не может быть пустым!")]
    public string Surname
    {
        get => surname;
        set => Set(ref surname, value, null);
    }

    [Required(ErrorMessage = "Данное поле не может быть пустым!")]
    public string Patronymic
    {
        get => patronymic;
        set => Set(ref patronymic, value, null);
    }

    [DateBirthday]
    public string DateBirth
    {
        get => dateBirth;
        set => Set(ref dateBirth, value, new() { new DateBirthdayAttribute() });
    }

    [PhoneNumber]
    public string NumberPhone
    {
        get => numberPhone;
        set => Set(ref numberPhone, value, new() { new PhoneNumberAttribute() });
    }

    [Required]
    public string UrlFaceImg
    {
        get => urlFaceImg;
        set => Set(ref urlFaceImg, value, null);
    }

    public List<LessonEntity> Lessons
    {
        get => lessons;
        set
        {
            if (value == lessons)
                return;
            lessons = value;
            OnPropertyChanged();
        }
    }

    public TeacherDataViewModel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository)
    {
        OnBack = new MainCommand(
            _ =>
            {
                using (var scope =  new ContainerScoped(AdminDIConteiner.Container))
                    scope.GetService<TeachersManagementView>().InitializeComponents();
            });

        OnSave = new MainCommand(
            _ =>
            {
                if (isSave ? true : Validatoreg.TryValidObject(this, out var results))
                {
                    teacherRepository.Add(
                        new TeacherEntity(Name, Surname, Patronymic, DateBirth, NumberPhone, UrlFaceImg, Lessons));

                    LogicaMessage.MessageOk("Преподователь успешно добавлен!");
                    OnBack.Execute(null);
                }
                else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
            });

        OnAddingImg = new MainCommand(
        _ =>
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите изображения мероприятия";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        if (fileName == urlFaceImg)
                            return;
                        urlFaceImg = fileName;
                        OnPropertyChanged("OnAddingImg");
                    }
                }
            }
        });

        OnDeletingImg = new MainCommand(
        _ =>
        {
            UrlFaceImg = "D:\\Документы\\Projects_CSharp\\GraduationProject\\Logica\\Img\\NoImg.png";
            OnPropertyChanged("OnDeletingImg");
        });
    }

    public void Set(ref string file, string value, List<ValidationAttribute>? validationAttributes, [CallerMemberName] string prop = "")
    {
        if (validationAttributes is null)
            validationAttributes = new();

        validationAttributes.Add(new RequiredAttribute() { ErrorMessage = "Данное поле не может быть пустым!" });

        file = value;

        if (!Validatoreg.TryValidValue(file, validationAttributes, out string errorMessage))
        {
            OnMassegeErrorProvider(errorMessage, prop);
            isSave = false;
            return;
        }

        isSave = true;
        OnMassegeErrorProvider("", prop);
        OnPropertyChanged(prop);
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    public void OnMassegeErrorProvider(string? errorMesege, [CallerMemberName] string prop = "")
        => ErrorMassegeProvider?.Invoke(this, new ErrorMessagePropertyArgs(errorMesege, new PropertyChangedEventArgs(prop)));
}
