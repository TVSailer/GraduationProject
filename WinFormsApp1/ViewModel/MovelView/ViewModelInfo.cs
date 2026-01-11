using Admin.ViewModels.Lesson;

namespace Admin.ViewModels.NotifuPropertyViewModel
{

    public class ViewModelInfo
    {
        public readonly List<FieldInfoAttribute?> fieldsInfo;
        public readonly List<ButtonInfoAttribute?> buttonsInfo;

        public ViewModelInfo(List<FieldInfoAttribute?> fieldsInfo, List<ButtonInfoAttribute?> buttonsInfo)
        {
            this.fieldsInfo = fieldsInfo;
            this.buttonsInfo = buttonsInfo;
        }
    }
}
