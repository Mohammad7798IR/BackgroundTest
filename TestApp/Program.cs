using Microsoft.EntityFrameworkCore;
using TestApp.BackgroundTask;
using TestApp.Context;
using TestApp.Models;
using TestApp.ImplementsRepository.Interfaces;
using TestApp.Implements.Interface;
using TestApp.Implements.Services;
using TestApp.ImplementsRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Services.AddHostedService<TestService>();

//builder.Services.AddHostedService<GetUserWorker>();

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

app.UseRouting();

app.UseHttpsRedirection();

//app.UseCors();

app.UseAuthorization();

app.UseEndpoints(entpoints =>
{
    entpoints
    .MapControllers();
});



app.Run();
