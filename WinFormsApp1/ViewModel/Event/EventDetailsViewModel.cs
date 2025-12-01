using Logica;
using DataAccess.Postgres.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using DataAccess.Postgres.Repository;
using WinFormsApp1.View;
using System.Reflection;
using CSharpFunctionalExtensions;

namespace WinFormsApp1.ViewModel.Event
{
    public class EventDetailsViewModel : INotifyPropertyChanged
    {
        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        public readonly EventEntity EventEntity;
        public Dictionary<string, bool>? SelectedImg { get; private set; } = new();
        public Dictionary<OnPropertyAddEventViewModel, Control> ControlOnProperty { get; private set; } = new();

        public ICommand OnBack { get; private set; }
        public ICommand OnUpdate { get; private set; }
        public ICommand OnDelete { get; private set; }
        public ICommand OnAddingImg { get; private set; }
        public ICommand OnDeletingImg { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string title;
        private string description;
        private string date;
        private string location;
        private string category;
        private string regisLink;
        private string organizer;
        private string maxPart;

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
        public string Date { get => date; set => date = value; }

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
        public string RegistrationLink
        {

            get
            {
                if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.RegisLink)) throw new ArgumentNullException();

                var control = ControlOnProperty[OnPropertyAddEventViewModel.RegisLink];
                if (string.IsNullOrWhiteSpace(regisLink))
                {
                    errorProvider.SetError(control, "Ссылка на регистрацию не может быть пустой");
                    return null;
                }
                if (!Uri.TryCreate(regisLink, UriKind.Absolute, out _))
                {
                    errorProvider.SetError(control, "Введите корректный URL");
                    return null;
                }

                errorProvider.SetError(control, "");
                return regisLink;
            }

            set => Set(OnPropertyAddEventViewModel.RegisLink, ref regisLink, value);
        }

        [Required]
        public string Organizer
        {
            get => Get(OnPropertyAddEventViewModel.Organizer, ref organizer);
            set => Set(OnPropertyAddEventViewModel.Organizer, ref organizer, value);
        }

        [Required]
        public string MaxParticipants
        {
            get 
            {
                if (!ControlOnProperty.ContainsKey(OnPropertyAddEventViewModel.MaxParticipants)) throw new ArgumentNullException();

                var control = ControlOnProperty[OnPropertyAddEventViewModel.MaxParticipants];
                if (string.IsNullOrEmpty(maxPart))
                {
                    errorProvider.SetError(control, "Данное поле не может быть пустым");
                    return null;
                }
                if (!int.TryParse(maxPart, null, out int rezult))
                {
                    errorProvider.SetError(control, "Значения целого числа");
                    return null;

                }
                if (rezult < 1)
                {
                    errorProvider.SetError(control, "Значения целого числа не может быть ниже нуля");
                    return null;
                }

                errorProvider.SetError(control, "");
                return maxPart;
            }
            set => Set(OnPropertyAddEventViewModel.MaxParticipants, ref maxPart, value);
        }

        public EventDetailsViewModel(Form mainForm, ICommand onBack, EventRepository eventRepository, int idEvent)
        {
            EventEntity = eventRepository.Get(idEvent);

            EventEntity.ImgsEvent?.ForEach(img => SelectedImg.Add(img.Url, false));

            title = EventEntity.Title;
            description = EventEntity.Description;
            Date = EventEntity.Date;
            location = EventEntity.Location;
            category = EventEntity.Location;
            maxPart = EventEntity.MaxParticipants.ToString();
            organizer = EventEntity.Organizer;
            regisLink = EventEntity.RegistrationLink;

            OnBack = onBack;
            OnUpdate = new MainCommand(
                _ =>
                {
                    if (Validatoreg.TryValidObject(this))
                    {
                        List<ImgEventEntity> imgs = new();

                        SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

                        eventRepository.Update(EventEntity.Id,
                            new EventEntity(Title, Description, Date, Location, Category, RegistrationLink, Organizer, int.Parse(MaxParticipants), imgs));

                        LogicaMessage.MessageOk("Данные мероприятия успешно обновленны!");
                    }
                });

            OnDelete = new MainCommand(
                _ =>
                {
                    eventRepository.Delete(EventEntity.Id);
                    OnBack.Execute(null);
                });

            OnAddingImg = new MainCommand(
                _ =>
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

                    OnPropertyChanged("OnAddingImg");
                });

            OnDeletingImg = new MainCommand(
                _ =>
                {
                    if (!SelectedImg.ContainsValue(true)) return;
                    SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
                    OnPropertyChanged("OnDeletingImg");
                });

            new EventDetailsView(this, mainForm);
        }

        private string Get(OnPropertyAddEventViewModel onPropertyAddEventViewModel, ref string file)
        {
            if (!ControlOnProperty.ContainsKey(onPropertyAddEventViewModel)) throw new ArgumentNullException();

            var control = ControlOnProperty[onPropertyAddEventViewModel];
            if (string.IsNullOrEmpty(file))
                errorProvider.SetError(control, "Данное поле не может быть пустым");

            errorProvider.SetError(control, "");
            return file;
        }

        private void Set(OnPropertyAddEventViewModel onPropertyAddEventViewModel, ref string file, string value, [CallerMemberName] string prop = "")
        {
            file = value;
            OnPropertyChanged(prop);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
