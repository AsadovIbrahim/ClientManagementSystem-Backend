using ClientManagementSystem.BL.Interfaces;
using ClientManagementSystem.BL.Services;
using ClientManagementSystem.DAL.Contexts;
using ClientManagementSystem.DAL.Interfaces;
using ClientManagementSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

//Repositories Registration
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientGroupRepository, ClientGroupRepository>();


//Services Registration
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientGroupService, ClientGroupService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")        
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
