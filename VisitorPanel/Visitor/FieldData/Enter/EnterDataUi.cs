using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DataAccess.PostgreSQL.Logger;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;

namespace Visitor.FieldData.Enter;

public class EnterDataUi(AuthRepository repository)
{
    public string? Login { get; set; }
    public string? Password { get; set; }
}

