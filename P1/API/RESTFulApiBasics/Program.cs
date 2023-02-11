/*
 * contains middle ware
 * <app> - middle ware
 * <builder> - services
 */
using DataFluentApi;
using LogicLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// for documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connection string 

//Db context classes we create using scafolding is a dependency to use its object reference in the EFSql Repo class
//Options.UseSqlServer

//dependency injection through services
var config = builder.Configuration.GetConnectionString("TrainersDb");

// Db Contect class we create using scafolding is a dependancy to use its object reference in the EFSql Repo class
// Options.UseSqlServer() will create DbContextOptions class that hold our connection string
builder.Services.AddDbContext<DataFluentApi.Entities.TrainersDbContext>(options => options.UseSqlServer(config));

builder.Services.AddScoped<ITrainerDetailEFRepo, TrainerDetailEFRepo>();
builder.Services.AddScoped<ITrainerDetailLogic, TrainerDetailLogic>();

builder.Services.AddScoped<ITrainerSkillEFRepo, TrainerSkillEFRepo>();
builder.Services.AddScoped<ITrainerSkillLogic, TrainerSkillLogic>();

builder.Services.AddScoped<ITrainerLocationEFRepo, TrainerLocationEFRepo>();
builder.Services.AddScoped<ITrainerLocationLogic, TrainerLocationLogic>();

builder.Services.AddScoped<ITrainerCompanyEFRepo, TrainerCompanyEFRepo>();
builder.Services.AddScoped<ITrainerCompanyLogic, TrainerCompanyLogic>();

builder.Services.AddScoped<ITrainerEducationEFRepo, TrainerEducationEFRepo>();
builder.Services.AddScoped<ITrainerEducationLogic, TrainerEducationLogic>();

builder.Services.AddScoped<Utility>();

//builder.Services.AddScoped<DataFluentApi.Entities.TrainersDbContext>();

//Service to add cache
builder.Services.AddMemoryCache();

//enabling CORS for any origin 
var AllowAllPolicy = "AllowAllPolicy";
builder.Services.AddCors(options =>
    options.AddPolicy(AllowAllPolicy, policy => {policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();}));

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use cors
app.UseCors();

//
app.UseHttpsRedirection();

//
app.UseAuthorization();

//
app.MapControllers();

//
app.Run();
