using ToDoTask.Domain.Tasks;

namespace ToDoTask.Domain.Users;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<TaskItem> TaskItems { get; set; } = default!;
}
