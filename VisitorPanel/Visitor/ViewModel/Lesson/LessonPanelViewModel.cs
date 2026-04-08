using System.Windows.Input;
using Domain.Entitys;

namespace Visitor.ViewModel.Lesson;

public class LessonPanelViewModel : General.ViewModel.ViewModel
{
    public string Title { get; set; }
    public TeacherEntity Teacher { get; set; }
    public string Description { get; set; }
    public IEnumerable<string>? Images { get; set; }
    public IEnumerable<ReviewEntity> ReviewEntites { get; set; }
    public ICommand Exit { get; set; }
    public ICommand CommentComand { get; set; }
    public string NameCommand { get; set; }
}