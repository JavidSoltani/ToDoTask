using ToDoTask.Domain.Users;

namespace ToDoTask.Domain.Tasks;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public bool IsCompleted { get; set; }
    public DateTime CreateDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
