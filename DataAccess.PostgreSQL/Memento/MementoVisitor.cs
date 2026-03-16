using DataAccess.PostgreSQL.Models;

namespace DataAccess.PostgreSQL.Memento;

public class MementoVisitor
{
    public VisitorEntity? Visitor { get; set; }

    public bool IsVisitor => Visitor is not null;
}