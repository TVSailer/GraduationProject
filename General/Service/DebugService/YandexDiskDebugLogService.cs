using Domain.Service.DebugService.BaseDebugService;
using YandexDisk.Client.Http;

namespace General.Service.DebugService;

public class YandexDiskDebugLogService(IDebugLogService debugLog) : ILogSaver
{
    public void SaveLog(RequestLog requestLog, ResponseLog responseLog)
    {
        debugLog.Message(requestLog.Headers + "\n" + responseLog.Headers);
    }
}