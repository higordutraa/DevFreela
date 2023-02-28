using DevFreela.API.Models;
using DevFreela.Application.Services.Inplementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

builder.Services.AddScoped<ExampleClass> (e=> new ExampleClass { Name="InitialStage"});

builder.Services.AddSingleton<DevFreelaDbContext>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();
//-------------------------------------------------------------------------------------------------------------------------------------//
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
