using ToDoTask.Application.Tasks.Dto;

namespace ToDoTask.Application.Tasks.Interfaces;

public interface ITaskItemRepository
{
    Task<bool> AddTask(AddTaskModel request, CancellationToken cancellationToken);
    Task<bool> EditTask(EditTaskModel request, CancellationToken cancellationToken);
    Task<List<GetTaskListItemModel>> GetList(int userId,CancellationToken cancellationToken);
}
