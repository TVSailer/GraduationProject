using Admin.View.Moduls.Teacher;
using Admin.ViewModel.NotifuPropertyViewModel;
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

public abstract class TeacherDataViewModel : NotifyPropertyViewModel
{
    public ICommand OnBack { get; protected set; }
    public ICommand OnSave { get; protected set; }
    public ICommand OnAddingImg { get; protected set; }
    public ICommand OnDeletingImg { get; protected set; }

    private string urlFaceImg = "D:\\Документы\\Projects_CSharp\\GraduationProject\\Logica\\Img\\NoImg.png";

    [RequiredCustom] public string Name { get; set => Set(ref field, value); }
    [RequiredCustom] public string Surname { get; set => Set(ref field, value); }
    [RequiredCustom] public string Patronymic { get; set => Set(ref field, value); }
    [DateBirthday] public string DateBirth { get; set => Set(ref field, value); }
    [PhoneNumber] public string NumberPhone { get; set => Set(ref field, value); }

    public string UrlFaceImg
    {
        get => urlFaceImg ?? throw new ArgumentNullException();
        set => Set(ref urlFaceImg, value);
    }

    public TeacherDataViewModel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository)
    {
        OnBack = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                    scope.GetService<TeacherManagementView>().InitializeComponents();
            });

        OnSave = new MainCommand(
            _ =>
            {
                if (Validatoreg.TryValidObject(this, out var results))
                {
                    teacherRepository.Add(
                        new TeacherEntity(Name, Surname, Patronymic, DateBirth, NumberPhone, UrlFaceImg));

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
}
