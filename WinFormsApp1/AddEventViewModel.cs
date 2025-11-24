using AdminApp.Forms;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
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
    private EventRepository eventRepository;
    
    public Dictionary<string, bool> SelectedImg { get; private set; } = new();
    public Dictionary<OnPropertyAddEventViewModel, Control> ControlOnProperty { get; private set; } = new();

    public ICommand OnBack { get; private set; }
    public ICommand OnSave { get; private set; }
    public ICommand OnAddingImg { get; private set; }
    public ICommand OnDeletingImg { get; private set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private string title;
    private string description;
    private string location;
    private string category;
    private string regisLink;
    private string organizer;

    [Required]
    public string Title
    {
        get => Get(OnPropertyAddEventViewModel.Title, ref title);
        set => Set(OnPropertyAddEventViewModel.Title, ref title, value);
    }

    [Required]
    public string Description
    {
        get => Get(OnPropertyAddEventViewModel.Description, ref description);
        set => Set(OnPropertyAddEventViewModel.Description, ref description, value);
    }

    [Required]
    public string Date { get; set; }

    [Required]
    public string Location
    {
        get => Get(OnPropertyAddEventViewModel.Location, ref location);
        set => Set(OnPropertyAddEventViewModel.Location, ref location, value);
    }

    [Required]
    public string Category
    {
        get => Get(OnPropertyAddEventViewModel.Category, ref category);
        set => Set(OnPropertyAddEventViewModel.Category, ref category, value);
    }

    [Required]
    public string RegisLink
    {

        get
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.RegisLink)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.RegisLink];
            if (string.IsNullOrWhiteSpace(regisLink))
                errorProvider.SetError(control, "Ссылка на регистрацию не может быть пустой");

            return regisLink;
        }
        set
        {
            if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.RegisLink)) throw new ArgumentNullException();

            var control = ControlOnProperty[OnPropertyAddEventViewModel.RegisLink];
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, "Ссылка на регистрацию не может быть пустой");
                regisLink = null;
                return;
            }

            if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            {
                errorProvider.SetError(control, "Введите корректный URL");
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
        get => Get(OnPropertyAddEventViewModel.Organizer, ref organizer);
        set => Set(OnPropertyAddEventViewModel.Organizer, ref organizer, value);
    }

    public int MaxParticipants { get; set; }

    public AddEventViewModel(Form mainForm, ICommand onBack, ApplicationDbContext dbContext)
    {
        OnBack = onBack;
        OnSave = new MainCommand(
            _ => 
            {
                if (Validatoreg.TryValidObject(this, false))
                {
                    List<ImgEventEntity> imgs = new();

                    SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

                    eventRepository.Add(
                        new EventEntity(Title, Description, Date, Location, Category, RegisLink, Organizer, MaxParticipants, imgs));
                }
            });
        OnAddingImg = new MainCommand(_ => AddImages());
        OnDeletingImg = new MainCommand(_ => DeleteImg());

        addEventView = new AddEventView(mainForm, this);
        eventRepository = new(dbContext);
    }

    public string Get(OnPropertyAddEventViewModel onPropertyAddEventViewModel, ref string file)
    {
        if (!ControlOnProperty.ContainsKey(onPropertyAddEventViewModel)) throw new ArgumentNullException();

        var control = ControlOnProperty[onPropertyAddEventViewModel];
        if (string.IsNullOrWhiteSpace(file))
            errorProvider.SetError(control, "Данное поле не может быть пустым");

        return file;
    }

    public void Set(OnPropertyAddEventViewModel onPropertyAddEventViewModel, ref string file, string value)
    {
        if (!ControlOnProperty.ContainsKey(onPropertyAddEventViewModel)) throw new ArgumentNullException();

        var control = ControlOnProperty[onPropertyAddEventViewModel];
        if (string.IsNullOrWhiteSpace(value))
        {
            errorProvider.SetError(control, "Данное поле не может быть пустым");
            file = null;
            return;
        }
        errorProvider.SetError(control, "");
        file = value;

        OnPropertyChanged();
    }

    private void AddImages()
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
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

        OnPropertyChanged();
    }
    
    private void DeleteImg()
    {
        if (!SelectedImg.ContainsValue(true)) return;

        SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));

        OnPropertyChanged();
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
 