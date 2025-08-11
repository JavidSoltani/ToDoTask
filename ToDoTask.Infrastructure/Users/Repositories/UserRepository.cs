using Microsoft.EntityFrameworkCore;
using ToDoTask.Application.Users.Dto;
using ToDoTask.Application.Users.Interfaces;
using ToDoTask.Domain.Users;
using ToDoTask.Infrastructure.Common;

namespace ToDoTask.Infrastructure.Users.Repositories;

public class UserRepository(
    ToDoTaskDbContext dbContext)
    : IUserRepository
{
    public async Task<bool> Add(AddUserModel request, CancellationToken cancellationToken)
    {
        var insertUser = new User()
        {
            CreateDate = DateTime.Now,
            FullName = request.FullName,
            IsActive = true,
            Password = request.Password,
            UserName = request.UserName
        };
        dbContext.Users.Add(insertUser);
        var rowEffected = await dbContext.SaveChangesAsync(cancellationToken);
        request.Id = insertUser.Id;
        return rowEffected > 0;
    }

    public async Task<bool> Edit(EditUserModel request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(w => w.Id == request.Id);
        if (user == null)
            return false;
        user.FullName = request.FullName;
        user.Password = request.Password;
        user.IsActive = request.IsActive;

        var rowEffected = await dbContext.SaveChangesAsync(cancellationToken);
        return rowEffected > 0;
    }

    public async Task<GetUserInfoModel> GetInfo(int id, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(w => w.Id == id);
        if (user == null)
            return new();

        return new()
        {
            CreateDate = user.CreateDate,
            FullName = user.FullName,
            IsActive = user.IsActive,
            UserName = user.UserName,
            Id = user.Id
        };
    }

    public async Task<List<GetUserInfoModel>> GetList(CancellationToken cancellation)
    {
        var users = await dbContext.Users.ToListAsync(cancellation);

        return (from i in users
                select new GetUserInfoModel()
                {
                    CreateDate = i.CreateDate,
                    FullName = i.FullName,
                    IsActive = i.IsActive,
                    UserName = i.UserName,
                    Id = i.Id
                }).ToList();
    }

    public async Task<bool> ValidUserName(string userName, CancellationToken cancellationToken)
        => !await dbContext.Users.AnyAsync(w=>w.UserName ==  userName, cancellationToken);

    public async Task<bool> ValidPassword(string Password, string userName, CancellationToken cancellationToken)
        => await dbContext.Users.AnyAsync(w => w.UserName == userName && w.Password == Password, cancellationToken);

    public async Task<bool> Login(LoginModel request, CancellationToken cancellationToken)
       => await dbContext.Users.AnyAsync(w => w.UserName == request.UserName && w.Password == request.Password, cancellationToken);

}
