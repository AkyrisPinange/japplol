using JAppInfos.Models;
using JAppInfos.Models.AppDbContext;
using JAppInfos.Services;
using JAppInfos.utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddHttpClient("riotClient", client =>
{
    client.BaseAddress = new Uri("https://br1.api.riotgames.com/lol/");
});
builder.Services.AddHttpClient("ddragon", client =>
{
    client.BaseAddress = new Uri("https://ddragon.leagueoflegends.com/cdn/14.6.1/data/pt_BR/");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddAuthorization();
builder.Services.AddMvc();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(
        config.GetConnectionString("DefaultConnection"), 
        ServerVersion
        .AutoDetect(config.GetConnectionString("DefaultConnection"))));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<RiotService>();
builder.Services.AddScoped<Utils>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.MapControllerRoute(
    name: "register",
    pattern: "api/register",
    defaults: new { controller = "Account", action = "Register" }
);


app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
