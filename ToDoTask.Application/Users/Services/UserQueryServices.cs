using ToDoTask.Application.Users.Dto;
using ToDoTask.Application.Users.Interfaces;

namespace ToDoTask.Application.Users.Services;

public class UserQueryServices(
    IUserRepository userRepository)
{
    public async Task<GetUserInfoModel> GetInfo(int id, CancellationToken cancellationToken)
       => await userRepository.GetInfo(id, cancellationToken);

    public async Task<List<GetUserInfoModel>> GetList(CancellationToken cancellationToken)
        => await userRepository.GetList(cancellationToken);

    public async Task<bool> LoginApp(LoginModel request, CancellationToken cancellationToken)
      => await userRepository.Login(request, cancellationToken);
}
