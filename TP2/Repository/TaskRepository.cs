using TarefasApp.Models;

namespace TarefasApp.Repository;

public class TaskRepository
{
    private readonly TaskDatabaseSingleton _taskDatabase;

    public TaskRepository()
    {
        _taskDatabase = TaskDatabaseSingleton.getInstance();
    }

    public void Add(TaskModel task)
    {
        _taskDatabase._tasks.Add(task);
    }

    public void Update(Guid id, TaskModel task)
    {
        var entity = this.Get(id);

        if (entity == null) return;

        entity.Title = task.Title;
        entity.Priority = task.Priority;
        entity.Description = task.Description;
    }

    public void Remove(Guid id)
    {
        var task = this.Get(id);

        if(task != null)
            _taskDatabase._tasks.Remove(task);
    }

    public ICollection<TaskModel> List()
    {
        return _taskDatabase._tasks;
    }

    public TaskModel Get(Guid id)
    {
        return _taskDatabase._tasks.FirstOrDefault(t => t.Id.Equals(id));
    }
}
