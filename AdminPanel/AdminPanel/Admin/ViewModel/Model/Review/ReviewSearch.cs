using Admin.ViewModel.Managment;

namespace Admin.ViewModel.Model.Review;

public class ReviewSearch : IParametersSearch<ReviewEntity, ReviewFieldSearch>
{
    public Func<ReviewFieldSearch, List<ReviewEntity>, List<ReviewEntity>> SearchFunc =>
        (obj, entitys) =>
            entitys
                .Where(e => e.Visitor.FIO.Name.StartsWith(obj.NameVisitor ?? ""))
                .Where(e => e.Visitor.FIO.Surname.StartsWith(obj.SurnameVisitor ?? ""))
                .ToList();
}