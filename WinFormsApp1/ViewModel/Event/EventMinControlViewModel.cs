//using Admin.View.Moduls.Event;
//using Admin.ViewModels;
//using Admin.ViewModels.NotifuPropertyViewModel;
//using DataAccess.Postgres.Models;
//using DataAccess.Postgres.Repository;
//using Logica;
//using Logica.CustomAttribute;
//using Logica.DI;
//using System.Windows.Input;
//using WinFormsApp1;

//public class EventMinControlViewModel : ViewModel<EventEntity>
//{
//    public Dictionary<string, bool> SelectedImg { get; private set; } = new();

//    public ICommand OnBack { get; protected set; }
//    public ICommand actjionSave { get; protected set; }
//    public ICommand OnAddingImg { get; protected set; }
//    public ICommand OnDeletingImg { get; protected set; }

//    private string date = DateTime.Now.ToString();

//    [RequiredCustom] public string Title { get; set => Set(ref field, value); }
//    [RequiredCustom] public string Description { get; set => Set(ref field, value); }
//    [RequiredCustom] public string Date { get => date; set => date = value; }
//    [RequiredCustom] public string Location { get; set => Set(ref field, value); }
//    [RequiredCustom] public string Category { get; set => Set(ref field, value); }
//    [HttpsLink] public string RegisLink { get; set => Set(ref field, value); }
//    [RequiredCustom] public string Organizer { get; set => Set(ref field, value); }
//    [MaxParticipants] public string MaxParticipants { get; set => Set(ref field, value); } = "1";

//    public EventMinControlViewModel(EventRepository eventRepository)
//    {
//        OnBack = new MainCommand(
//             _ =>
//             {
//                 using (var scope = AdminDI.CreateDIScope())
//                     scope.GetService<EventManagementView>();
//             });

//        actjionSave = new MainCommand(
//            _ =>
//            {
//                if (Validatoreg.TryValidObject(this, out var results, false))
//                {
//                    List<ImgEventEntity> imgs = new();

//                    SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

//                    eventRepository.Add(
//                        new EventEntity(Title, Description, Date, Location, Category, RegisLink, Organizer, int.Parse(MaxParticipants), imgs));

//                    LogicaMessage.MessageOk("Мероприятие успешно добавленно!");
//                    OnBack.Execute(null);
//                }
//                else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
//            });

//        OnAddingImg = new MainCommand(
//        _ =>
//        {
//            using (var openFileDialog = new OpenFileDialog())
//            {
//                openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
//                openFileDialog.Title = "Выберите изображения мероприятия";
//                openFileDialog.Multiselect = true;

//                if (openFileDialog.ShowDialog() == DialogResult.OK)
//                {
//                    foreach (var fileName in openFileDialog.FileNames)
//                    {
//                        if (!SelectedImg.ContainsKey(fileName))
//                            SelectedImg.Add(fileName, false);
//                    }
//                }
//            }

//            OnPropertyChanged("OnAddingImg");
//        });

//        OnDeletingImg = new MainCommand(
//        _ =>
//        {
//            if (!SelectedImg.ContainsValue(true)) return;
//            SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
//            OnPropertyChanged("OnDeletingImg");
//        });
//    }

//    public override IViewModel<EventEntity> Initialize(object value)
//    {
//        throw new NotImplementedException();
//    }

//    public override void SetData(EventEntity value)
//    {
//        throw new NotImplementedException();
//    }
//}
