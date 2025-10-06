using DataAccess.Postgres.Models;

namespace Visitor;

public static class ProgramVisitor
{
    public static void Run(VisitorEntity visitor)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormAttendance());
    }

    public static void Run()
    {
        ApplicationConfiguration.Initialize();
        Application.Run();
    }
}
