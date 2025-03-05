using Microsoft.EntityFrameworkCore;
using Todos.WepAPI.Context;
using Todos.WepAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getAll", (ApplicationDbContext context) => Results.Ok(context.Todos.ToList()));

app.MapGet("/create", (ApplicationDbContext context, string work) =>
{

    Todo todo = new()
    {
        Work = work
    };

    context.Add(todo);
    context.SaveChanges();
    Results.Ok(work);
});

using (var scope = app.Services.CreateScope()) 
{
    var srv = scope.ServiceProvider;
    var context=srv.GetRequiredService<ApplicationDbContext>(); 
    context.Database.Migrate();
}

app.Run();
