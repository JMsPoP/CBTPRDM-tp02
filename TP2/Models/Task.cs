namespace TarefasApp.Models;

public class TaskModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public short Priority { get; set; }

    public TaskModel(Guid id, string title, string description, DateTime createAt, short priority)
    {
        Id = id;
        Title = title;
        Description = description;
        CreateAt = createAt;
        Priority = priority;
    }

    public TaskModel(string title, string description, short priority)
        : this(Guid.NewGuid(), title, description, DateTime.Now, priority)
    {
    }
}
