using Microsoft.EntityFrameworkCore;
using TestApp.BackgroundTask;
using TestApp.Context;
using TestApp.Models;
using TestApp.Repository;
using TestApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<TestService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
           .AddEntityFrameworkStores<TestDbContext>();

builder.Services.AddDbContextPool<TestDbContext>(optionsAction =>
{
    optionsAction.UseInMemoryDatabase(databaseName: "InMemoryTest");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
