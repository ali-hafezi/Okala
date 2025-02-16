using Microsoft.EntityFrameworkCore;
using Okala.Command.EF;
using Okala.Application.Commands.Users;
using Okala.Domain.Entities;
using Okala.Command.EF.CryptoRepo;
using Okala.OnlineDataReader;

var builder = WebApplication.CreateBuilder(args);

var cnnString = builder.Configuration.GetConnectionString("Cnn");
builder.Services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<ICryptoRepository, CryptoRepository>();

builder.Services.AddScoped<IFetchData, OnlineFetchData>();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapDefaultControllerRoute();

app.Run();
