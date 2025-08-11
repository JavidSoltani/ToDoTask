namespace ToDoTask.Application.Users.Dto;

public class GetUserInfoModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
}