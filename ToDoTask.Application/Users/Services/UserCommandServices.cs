using ToDoTask.Application.Common;
using ToDoTask.Application.Users.Dto;
using ToDoTask.Application.Users.Interfaces;

namespace ToDoTask.Application.Users.Services;

public class UserCommandServices(
    IUserRepository userRepository)
{
    public async Task<string> AddUser(AddUserModel request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.UserName))
            return "required UserName";
        if (string.IsNullOrEmpty(request.FullName) || request.FullName.Split(" ").Length < 2)
            return "Input Valid FullName for Example 'firstNme LastName'";
        if (string.IsNullOrEmpty(request.Password))
            return "required Password";
        if (request.Password != request.RePassword)
            return "password not equal RePassword";

        if (!await userRepository.ValidUserName(request.UserName, cancellationToken))
            return "this UserName used another user";

        request.Password = request.Password.HashPassword();

        var result = await userRepository.Add(request, cancellationToken);
        if (!result)
            return "Error in Register user";
        return string.Empty;
    }

    public async Task<string> EditUser(EditUserModel request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return "Please Select User for Edit";
        if (string.IsNullOrEmpty(request.FullName) || request.FullName.Split(" ").Length < 2)
            return "Input Valid FullName for Example 'firstNme LastName'";
        if (string.IsNullOrEmpty(request.CurrentPassword))
            return "required Current Password";
        if (string.IsNullOrEmpty(request.Password))
            return "required Password";
        if (request.Password == request.CurrentPassword)
            return "Password not equal current password";

        if (request.Password != request.RePassword)
            return "password not equal RePassword";

        if (!await userRepository.ValidPassword(request.Password.HashPassword(), request.UserName, cancellationToken))
            return "this UserName used another user";

        request.Password = request.Password.HashPassword();

        var result = await userRepository.Edit(request, cancellationToken);
        if (!result)
            return "Error in Edit user";
        return string.Empty;
    }
}
