using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using TestApp.ImplementsRepository.Interfaces;
using TestApp.Implements.Interface;
using TestApp.Implements.Services;
using TestApp.ImplementsRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<TestDbContext>();

builder.Services.AddDbContextPool<TestDbContext>(optionsAction =>
{
    optionsAction.UseInMemoryDatabase(databaseName: "InMemoryTest");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(entpoints =>
{
    entpoints
    .MapControllers();
});

app.Run();
