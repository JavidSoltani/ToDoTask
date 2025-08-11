using ToDoTask.Application.Tasks.Dto;
using ToDoTask.Application.Tasks.Interfaces;

namespace ToDoTask.Application.Tasks.Services;

public class TaskCommandService(ITaskItemRepository taskRepository)
{
    public async Task<string> AddTask(AddTaskModel request, CancellationToken cancellationToken)
    {
        if (request.UserId <= 0)
            return "Please First Login";
        if (string.IsNullOrEmpty(request.Title))
            return "Please Input Text for this task";

        var result = await taskRepository.AddTask(request, cancellationToken);
        if (!result)
            return "error in Register Task";
        return string.Empty;
    }

    public async Task<string> EditTask(EditTaskModel request, CancellationToken cancellationToken)
    {
        if (request.UserId <= 0)
            return "Please First Login";
        if (request.Id <= 0)
            return "Please Select Task For Edit";
        if (string.IsNullOrEmpty(request.Title))
            return "Please Input Text for this task";

        var result = await taskRepository.EditTask(request, cancellationToken);
        if (!result)
            return "error in Edit Task";
        return string.Empty;
    }
}
