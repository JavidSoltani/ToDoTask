using ToDoTask.Application.Users.Dto;

namespace ToDoTask.Application.Users.Interfaces;

public interface IUserRepository
{
    Task<bool> Add(AddUserModel request, CancellationToken cancellationToken);
    Task<bool> Edit(EditUserModel request, CancellationToken cancellationToken);
    Task<GetUserInfoModel> GetInfo(int id, CancellationToken cancellationToken);
    Task<List<GetUserInfoModel>> GetList(CancellationToken cancellationToken);
    Task<bool> Login(LoginModel request, CancellationToken cancellationToken);
    Task<bool> ValidUserName(string userName, CancellationToken cancellationToken);
    Task<bool> ValidPassword(string password, string userName, CancellationToken cancellationToken);
}
