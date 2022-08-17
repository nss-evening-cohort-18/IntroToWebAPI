using IntroToWebAPI.Interfaces;
using IntroToWebAPI.Repositories;


/*  
 *  this object will automatically handle the HTTP pipeline and routes for us,
 *  something that would be a pain in the backside to do manually.
 *  don't try to recreate the wheel! focus on the most important/productive task.
 *  abstract away repetetive tasks, like handling routes and such and make endpoints that
 *  return results to the client
 */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*  
 *  Register your repositories here by adding them to the Services of your app.
 *  This allows them to be used with Dependency Injection (DI).
 *  When ASP.NET automatically creates instances of your controllers, it will also
 *  create any necessary instances of things needed by your controller, such as the repo,
 *  as long as it's registered here and defined in the constructor of the controller.
 */
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddControllers();

/*
 *  all this swagger stuff is what auto creates your docs, that's a wonderful thing!
 */
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
