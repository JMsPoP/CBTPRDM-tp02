using TarefasApp.Models;

namespace TarefasApp.Repository;

public class TaskDatabaseSingleton
{
    private static TaskDatabaseSingleton _instance = null;
    public List<TaskModel> _tasks;

    private TaskDatabaseSingleton()
    {
        _tasks = new List<TaskModel>();
    }

    public static TaskDatabaseSingleton getInstance()
    {
        if(_instance == null)
            _instance = new TaskDatabaseSingleton();

        return _instance;
    }
}
