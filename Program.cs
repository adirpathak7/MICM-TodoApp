using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));


builder.Services.AddScoped<SqlTodoService>();
builder.Services.AddScoped<LocalTodoService>();
builder.Services.AddScoped<FileTodoService>();
builder.Services.AddScoped<TodoServiceFactory>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("TodoFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TodoFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
