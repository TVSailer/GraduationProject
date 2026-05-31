using System.Diagnostics;
using Domain.Service.DebugService.BaseDebugService;

namespace Domain.Service.DebugService;

public class DebugLogService : IDebugLogService
{
    public void Message(string message)
    {
        Debug.WriteLine(message);
    }
}