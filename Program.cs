using JAppInfos.handler;
using JAppInfos.Models;
using JAppInfos.Models.AppDbContext;
using JAppInfos.Services;
using JAppInfos.utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true, 
        ValidateAudience = true, 
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(config["Jwt:key"]!)),
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
       
    };
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
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<RiotService>();
builder.Services.AddScoped<Utils>();
builder.Services.AddScoped<GlobalMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
