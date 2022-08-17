//this object will automatically handle the HTTP pipeline and routes for us,
//something that would be a pain in the backside to do manually.
//don't try to recreate the wheel! focus on the most important task.
//abstract away repetetive tasks, like handling routes and such
using IntroToWebAPI.Interfaces;
using IntroToWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//we'll see more about that when we get a database and repositories
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//all this swagger stuff is what auto creates your docs, that's a wonderful thing!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
