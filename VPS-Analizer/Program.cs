using MeneMarket.Brokers.Storages;
using MeneMarket.Services.Foundations.Users;
using VPS_Analizer.Services.Orchestrations.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();