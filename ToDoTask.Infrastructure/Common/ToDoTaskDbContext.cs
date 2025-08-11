using Microsoft.EntityFrameworkCore;
using ToDoTask.Domain.Users;
using ToDoTask.Domain.Tasks;



namespace ToDoTask.Infrastructure.Common;

public class ToDoTaskDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    public ToDoTaskDbContext(DbContextOptions<ToDoTaskDbContext> options): base(options)
    {
        
    }
}
