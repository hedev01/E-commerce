using System.Text;
using E_Commers.Application.InterFaces;
using E_Commers.Application.Services;
using E_Commers.Application.UseCases;
using E_Commers.Application.Writes;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using E_Commers.Infrastructure.Data;
using E_Commers.Infrastructure.Repositories;
using E_Commers.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 1. رجیستر کردن UserRepository (همانطور که بود)
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRoleRepository , RoleRepository>();
builder.Services.AddScoped<IRoleUseCase, RoleUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserUseCase , UserUseCase>();

// 2. رجیستر کردن JwtTokenService
// دقت کنید که فضای نام دقیق کلاس JwtTokenService را وارد کنید
// فرض می کنیم کلاس شما در E_Commers.Application.Services قرار دارد
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// 3. رجیستر کردن AccountUseCases (همانطور که بود)
// اطمینان حاصل کنید که فضای نام Application.Writes درست است
builder.Services.AddScoped<IAccountUseCases, AccountUseCases>();
//builder.Services.AddScoped<AccountUseCases>();
builder.Services.AddDbContext<Context>(option => {
    option
        .UseSqlServer("Data Source=.;Initial catalog=E-Commerce; Integrated Security=True;trustservercertificate=true");
});

builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy",
        policy => policy.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());
});
///this for make authorization to Admin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

builder.Services.AddIdentity<ApplicationUserIdentity, IdentityRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIss"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAud"],
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
