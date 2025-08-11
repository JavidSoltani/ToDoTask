namespace ToDoTask.Application.Tasks.Dto;

public class EditTaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public bool IsComplete { get; set; }
    public int UserId { get; set; }
}