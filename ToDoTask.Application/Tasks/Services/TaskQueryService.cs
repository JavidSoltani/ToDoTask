using ToDoTask.Application.Tasks.Dto;
using ToDoTask.Application.Tasks.Interfaces;

namespace ToDoTask.Application.Tasks.Services;

public class TaskQueryService(ITaskItemRepository taskRepository)
{
    public async Task<List<GetTaskListItemModel>> GetList(int userId,CancellationToken cancellationToken)
        => await taskRepository.GetList(userId,cancellationToken);
}
