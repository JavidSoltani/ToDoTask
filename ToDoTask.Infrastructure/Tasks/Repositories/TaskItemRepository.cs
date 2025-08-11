using Microsoft.EntityFrameworkCore;
using ToDoTask.Application.Tasks.Dto;
using ToDoTask.Application.Tasks.Interfaces;
using ToDoTask.Domain.Tasks;
using ToDoTask.Infrastructure.Common;

namespace ToDoTask.Infrastructure.Tasks.Repositories;

public class TaskItemRepository(
    ToDoTaskDbContext dbContext)
    : ITaskItemRepository
{
    public async Task<bool> AddTask(AddTaskModel request, CancellationToken cancellationToken)
    {
        var insertTask = new TaskItem()
        {
            CreateDate = DateTime.Now,
            IsCompleted = request.IsComplete,
            Title = request.Title,
            UserId = request.UserId
        };

        var result = dbContext.TaskItems.Add(insertTask);
        var rowEffected = await dbContext.SaveChangesAsync(cancellationToken);
        request.id = insertTask.Id;

        return rowEffected > 0;
    }

    public async Task<bool> EditTask(EditTaskModel request, CancellationToken cancellationToken)
    {
        var task = await dbContext.TaskItems.FirstOrDefaultAsync(w => w.Id == request.Id && w.UserId == request.UserId);

        if (task == null)
            return false;

        task.Title = request.Title;
        task.IsCompleted = request.IsComplete;
        var rowEffected = await dbContext.SaveChangesAsync(cancellationToken);
        return rowEffected > 0;
    }

    public async Task<List<GetTaskListItemModel>> GetList(int userId,CancellationToken cancellationToken)
    {
        var result = await dbContext.TaskItems
            .Include(i=>i.User)
            .Where(w=>w.UserId == userId)
            .ToListAsync(cancellationToken);

        return (from i in result
                select new GetTaskListItemModel ()
                {
                    Id = i.Id,
                    IsComplete = i.IsCompleted,
                    Title = i.Title,
                    UserName = i.User.FullName
                }).ToList();
    }
}
