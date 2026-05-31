namespace Domain.Service.TaskService.BaseTaskService;

public interface ITaskOperation
{
    public Task AddTask(CancellationTokenSource cancellationTokenSource, Task task);
    public void WhenAll();
}