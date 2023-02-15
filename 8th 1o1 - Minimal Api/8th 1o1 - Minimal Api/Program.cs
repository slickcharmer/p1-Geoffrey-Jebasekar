using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(options =>
 options.UseInMemoryDatabase("UserList")   );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Http Get

app.MapGet("/", () => "Hello world");
app.MapGet("/users/complete", async (UserContext user) =>
await user.Users.ToListAsync());
app.MapGet("/users/{id}", async (int id, UserContext user) =>
await user.Users.FindAsync(id));




// Http Post

app.MapPost("/users", async (User _user, UserContext user) =>
{
    user.Users.Add(_user);
    await user.SaveChangesAsync();

});




// Http Delete
app.MapDelete("/user/{id}", async (int id, UserContext user) =>
{
    if (await user.Users.FindAsync(id) is User _user)
    {
        user.Users.Remove(_user);
        await user.SaveChangesAsync();
        return Results.Ok(_user);
    }
    return Results.NotFound();
});




// Http Put

app.MapPut("/user/{id}", async (int id, User _user, UserContext user) =>
{
    var ids = await user.Users.FindAsync(id);
    if (ids is null) return Results.NotFound();
    ids.name = _user.name;
    ids.age = _user.age;
    await user.SaveChangesAsync();
    return Results.NoContent();

});


app.Run();


public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
}

public class UserContext : DbContext
{
    public UserContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}












//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}