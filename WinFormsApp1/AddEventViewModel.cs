using AdminApp.Forms;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using Logica;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public enum OnPropertyAddEventViewModel
{
    Title,
    Description,
    Date,
    Location,
    Category,
    RegisLink,
    Organizer,
    MaxParticipants,
    ImgsEvent
}

public class AddEventViewModel : INotifyPropertyChanged
{
    private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink};
    private AddEventView addEventView;

    public event PropertyChangedEventHandler? PropertyChanged;
    public Dictionary<OnPropertyAddEventViewModel, Control> ControlOnProperty { get; private set; } = new();

    public ICommand OnBack { get; private set; }
    public ICommand OnSave { get; private set; }
    public ICommand OnAddingImg { get; private set; }
    public ICommand OnDeletingImg { get; private set; }


    private string title;
    private string description;
    private string date;
    private string location;
    private string category;
    private string regisLink;
    private string organizer;

    [Required]
    public string Title
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Title];
            if (string.IsNullOrWhiteSpace(title))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return title;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Title];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                title = null;
                return;
            }
            errorProvider.SetError(control, "");
            title = value;
        }
    }

    [Required]
    public string Description
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Description];
            if (string.IsNullOrWhiteSpace(description))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return description;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Description];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                description = null;
                return;
            }
            errorProvider.SetError(control, "");
            description = value;
        }
    }

    [Required]
    public string Date
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Date];
            if (DateTime.Parse(control.Text) < DateTime.Now)
                errorProvider.SetError(control, "Дата мероприятия не может быть в прошлом");

            return date;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Date];
            if (DateTime.Parse(value) < DateTime.Now)
            {
                errorProvider.SetError(control, "Дата мероприятия не может быть в прошлом");
                date = null;
                return;
            }
            errorProvider.SetError(control, "");
            date = value;
        }
    }

    [Required]
    public string Location
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Location];
            if (string.IsNullOrWhiteSpace(location))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return location;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Location];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                location = null;
                return;
            }
            errorProvider.SetError(control, "");
            location = value;
        }
    }

    [Required]
    public string Category
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Category];
            if (string.IsNullOrWhiteSpace(category))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return category;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Category];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                category = null;
                return;
            }
            errorProvider.SetError(control, "");
            category = value;
        }
    }

    [Required]
    public string RegisLink
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.RegisLink];
            if (string.IsNullOrWhiteSpace(regisLink))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return regisLink;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.RegisLink];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                regisLink = null;
                return;
            }
            errorProvider.SetError(control, "");
            regisLink = value;
        }
    }

    [Required]
    public string Organizer
    {
        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Organizer];
            if (string.IsNullOrWhiteSpace(organizer))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            return organizer;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.Date)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.Organizer];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Данное поле не может быть пустым");
                organizer = null;
                return;
            }
            errorProvider.SetError(control, "");
            organizer = value;
        }
    }

    public int MaxParticipants { get; set; }
    public List<ImgEventEntity>? ImgsEvent => new();

    public AddEventViewModel(Form mainForm, ICommand onBack, ApplicationDbContext dbContext)
    {
        OnBack = onBack;
        OnSave = new MainCommand(_ => Validatoreg.TryValidObject(this, false));

        addEventView = new AddEventView(mainForm, this);
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
