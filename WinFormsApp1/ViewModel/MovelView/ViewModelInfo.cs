using Admin.ViewModels.Lesson;

namespace Admin.ViewModels.NotifuPropertyViewModel
{

    public class ViewModelInfo
    {
        public readonly List<FieldInfoUIAttribute?> fieldsInfo;
        public readonly List<ButtonInfoAttribute?> buttonsInfo;

        public ViewModelInfo(List<FieldInfoUIAttribute?> fieldsInfo, List<ButtonInfoAttribute?> buttonsInfo)
        {
            this.fieldsInfo = fieldsInfo;
            this.buttonsInfo = buttonsInfo;
        }
    }
}
