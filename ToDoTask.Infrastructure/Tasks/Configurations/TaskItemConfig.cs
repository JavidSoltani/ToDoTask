using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask.Domain.Tasks;

namespace ToDoTask.Infrastructure.Tasks.Configurations;

public class TaskItemConfig : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
        builder.Property(p=>p.Title).HasMaxLength(512).IsRequired();
    }
}
