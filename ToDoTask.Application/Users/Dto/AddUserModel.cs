using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.Application.Users.Dto;

public class AddUserModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RePassword { get; set; } = default!;
}
