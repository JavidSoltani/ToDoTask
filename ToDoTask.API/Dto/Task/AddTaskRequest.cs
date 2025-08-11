namespace ToDoTask.API.Dto.Task;

public class AddTaskRequest
{
    public string Title { get; set; } = default!;
    public bool IsComplete { get; set; }

}
