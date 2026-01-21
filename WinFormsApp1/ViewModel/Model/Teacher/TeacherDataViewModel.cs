//using Admin.View.Moduls.TeacherFIO;
//using Admin.ViewModels.NotifuPropertyViewModel;
//using DataAccess.Postgres.Models;
//using DataAccess.Postgres.Repository;
//using Logica;
//using Logica.CustomAttribute;
//using Logica.DI;
//using Logica.Img;
//using Logica.Massage;
//using Logica.Message;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.CompilerServices;
//using System.Windows.Input;
//using WinFormsApp1;

//public abstract class TeacherDataViewModel : ViewModelEntity<EventEntity>
//{
//    public ICommand OnBack { get; protected set; }
//    public ICommand actjionSave { get; protected set; }

//    [RequiredCustom] public string Name { get; set => TryValidProperty(ref field, value); }
//    [RequiredCustom] public string Surname { get; set => TryValidProperty(ref field, value); }
//    [RequiredCustom] public string Patronymic { get; set => TryValidProperty(ref field, value); }
//    [DateBirthday] public string DateBirth { get; set => TryValidProperty(ref field, value); }
//    [PhoneNumber] public string NumberPhone { get; set => TryValidProperty(ref field, value); }

//    public TeacherDataViewModel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository)
//    {
//        OnBack = new MainCommand(
//            _ =>
//            {
//                using (var scope = AdminDI.CreateDIScope())
//                    scope.GetService<TeacherManagementView>();
//            });

//        actjionSave = new MainCommand(
//            _ =>
//            {
//                if (Validatoreg.TryValidObject(this, out var results))
//                {
//                    teacherRepository.Add(
//                        new TeacherEntity(Name, Surname, Patronymic, DateBirth, NumberPhone, UrlFaceImg));

//                    LogicaMessage.MessageOk("Преподователь успешно добавлен!");
//                    OnBack.Execute(null);
//                }
//                else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
//            });

//        OnAddingImg = new MainCommand(
//        _ =>
//        {
//            ImageDialog.WorkWithImages(fileName =>
//            {
//                if (fileName == UrlFaceImg) return;
//                UrlFaceImg = fileName;
//            }, false);

//            OnPropertyChanged("OnAddingImg");
//        });

//        OnDeletingImg = new MainCommand(
//        _ =>
//        {
//            UrlFaceImg = "D:\\Документы\\Projects_CSharp\\GraduationProject\\Logica\\Img\\NoImg.png";
//            OnPropertyChanged("OnDeletingImg");
//        });
//    }
//}
