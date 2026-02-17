using DataAccess.Postgres.Models;

namespace Visitor;

public static class ProgramVisitor
{
    public static void Run(VisitorEntity visitor)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new AttendanceForm());
    }

    public static void Run()
    {
        ApplicationConfiguration.Initialize();
        Application.Run();
    }
}
