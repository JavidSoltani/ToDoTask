namespace ToDoTask.Application.Tasks.Dto;

public class GetTaskListItemModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public bool IsComplete { get; set; }
    public string UserName { get; set; } = default!;
}