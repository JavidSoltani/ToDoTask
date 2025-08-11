namespace ToDoTask.Application.Users.Dto;

public class EditUserModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string CurrentPassword { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RePassword { get; set; } = default!;
    public bool IsActive { get; set; }
}
