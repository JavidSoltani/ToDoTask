using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.Application.Tasks.Dto;

public class AddTaskModel
{
    public int id { get; set; }
    public string Title { get; set; } = default!;
    public bool IsComplete { get; set; }
    public int UserId { get; set; }
}
