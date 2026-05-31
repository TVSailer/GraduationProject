using Domain.Service.DebugService.BaseDebugService;
using Domain.Service.TaskService.BaseTaskService;

namespace Domain.Service.TaskService;

public class TaskOperation(IDebugLogService debugLogLog) : ITaskOperation
{
    private readonly Dictionary<CancellationTokenSource, List<Task>> _tasks = [];

    public Task AddTask(CancellationTokenSource cancellationTokenSource, Task task)
    {
        if (!_tasks.ContainsKey(cancellationTokenSource))
            _tasks.Add(cancellationTokenSource, []);

        _tasks[cancellationTokenSource].Add(task);
        task.ContinueWith(_tasks[cancellationTokenSource].Remove, TaskScheduler.Default);

        return task;
    }

    public async void WhenAll()
    {
        try
        {
            if (_tasks.Count == 0) return;

            try
            {
                foreach (var task in _tasks)
                {
                    await task.Key.CancelAsync();
                    try
                    {
                        await Task.WhenAll(task.Value);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    finally
                    {
                        task.Key.Dispose();
                    }
                }

                _tasks.Clear();
            }
            catch (System.Exception e)
            {
                debugLogLog.Message(e.Message);
                throw;
            }
        }
        catch (System.Exception e)
        {
            debugLogLog.Message(e.Message);
            throw;
        }
    }
}