using Microsoft.EntityFrameworkCore;
using ToDoTask.Application.Tasks.Interfaces;
using ToDoTask.Application.Tasks.Services;
using ToDoTask.Application.Users.Interfaces;
using ToDoTask.Application.Users.Services;
using ToDoTask.Infrastructure.Common;
using ToDoTask.Infrastructure.Tasks.Repositories;
using ToDoTask.Infrastructure.Users.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToDoTaskDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<UserQueryServices>();
builder.Services.AddScoped<UserCommandServices>();
builder.Services.AddScoped<TaskQueryService>();
builder.Services.AddScoped<TaskCommandService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
