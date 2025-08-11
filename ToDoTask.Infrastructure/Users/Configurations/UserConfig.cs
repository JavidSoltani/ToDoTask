using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask.Domain.Users;

namespace ToDoTask.Infrastructure.Users.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.FullName).HasMaxLength(50).IsRequired();
        builder.Property(p=>p.Password).HasMaxLength(512).IsRequired();
        builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
    }
}
