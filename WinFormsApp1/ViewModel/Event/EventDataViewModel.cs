using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using Logica.Massage;
using Logica.Message;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1.View.Event;
using WinFormsApp1;

public abstract class EventDataViewModel : INotifyPropertyChanged, IMessageErrorProvider
{
    public Dictionary<string, bool> SelectedImg { get; private set; } = new();

    public ICommand OnBack { get; protected set; }
    public ICommand OnSave { get; protected set; }
    public ICommand OnAddingImg { get; protected set; }
    public ICommand OnDeletingImg { get; protected set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event ErrorMessegePropertyHandler? ErrorMassegeProvider;

    private string title;
    private string description;
    private string date = DateTime.Now.ToString();
    private string location;
    private string category;
    private string regisLink;
    private string organizer;
    private string maxParticipants;

    [Required]
    public string Title
    {
        get => Get(ref title);
        set => Set(ref title, value);
    }

    [Required]
    public string Description
    {
        get => Get(ref description);
        set => Set(ref description, value);
    }

    [Required]
    public string Date { get => date; set => date = value; }

    [Required]
    public string Location
    {
        get => Get(ref location);
        set => Set(ref location, value);
    }

    [Required]
    public string Category
    {
        get => Get(ref category);
        set => Set(ref category, value);
    }

    [Required]
    public string RegisLink
    {

        get
        {
            if (string.IsNullOrWhiteSpace(regisLink))
                OnMassegeErrorProvider("Ссылка на регистрацию не может быть пустой");

            return regisLink;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                OnMassegeErrorProvider("Ссылка на регистрацию не может быть пустой");
                regisLink = null;
                return;
            }

            if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            {
                OnMassegeErrorProvider("Введите корректный URL");
                regisLink = null;
                return;
            }

            OnMassegeErrorProvider("");
            regisLink = value;
        }
    }

    [Required]
    public string Organizer
    {
        get => Get(ref organizer);
        set => Set(ref organizer, value);
    }

    [Required]
    public string MaxParticipants
    {
        get
        {
            if (string.IsNullOrEmpty(maxParticipants))
            {
                OnMassegeErrorProvider("Данное поле не может быть пустым");
                return null;
            }
            if (!int.TryParse(maxParticipants, null, out int rezult))
            {
                OnMassegeErrorProvider("Значения целого числа");
                return null;

            }
            if (rezult < 1)
            {
                OnMassegeErrorProvider("Значения целого числа не может быть ниже нуля");
                return null;
            }

            OnMassegeErrorProvider("");
            return maxParticipants;
        }
        set => Set(ref maxParticipants, value);
    }

    public EventDataViewModel(EventRepository eventRepository)
    {
        OnBack = new MainCommand(
             _ =>
             {
                 using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                     scope.GetService<EventManagementView>().InitializeComponents();
             });

        OnSave = new MainCommand(
            _ =>
            {
                if (Validatoreg.TryValidObject(this, false))
                {
                    List<ImgEventEntity> imgs = new();

                    SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

                    eventRepository.Add(
                        new EventEntity(Title, Description, Date, Location, Category, RegisLink, Organizer, int.Parse(MaxParticipants), imgs));

                    LogicaMessage.MessageOk("Мероприятие успешно добавленно!");
                    OnBack.Execute(null);
                }
            });

        OnAddingImg = new MainCommand(
        _ =>
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите изображения мероприятия";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        if (!SelectedImg.ContainsKey(fileName))
                            SelectedImg.Add(fileName, false);
                    }
                }
            }

            OnPropertyChanged("OnAddingImg");
        });

        OnDeletingImg = new MainCommand(
        _ =>
        {
            if (!SelectedImg.ContainsValue(true)) return;
            SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
            OnPropertyChanged("OnDeletingImg");
        });
    }


    public string Get(ref string file, [CallerMemberName] string prop = "")
    {
        if (string.IsNullOrWhiteSpace(file))
            OnMassegeErrorProvider("Данное поле не может быть пустым", prop);
        return file;
    }

    public void Set(ref string file, string value, [CallerMemberName] string prop = "")
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            OnMassegeErrorProvider("Данное поле не может быть пустым", prop);
            file = null;
            return;
        }
        file = value;

        OnMassegeErrorProvider("", prop);
        OnPropertyChanged(prop);
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    public void OnMassegeErrorProvider(string errorMesege, [CallerMemberName] string prop = "")
        => ErrorMassegeProvider?.Invoke(this, new ErrorMessagePropertyArgs(errorMesege, new PropertyChangedEventArgs(prop)));
}
 