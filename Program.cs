using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Data.SqlClient;
using ZurichAPI.Data;
using ZurichAPI.Repository.Impl;
using ZurichAPI.Repository;
using ZurichAPI.Utils;

var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

var config = configuration.Build();
var connectionStrings = config.GetConnectionString("DefaultConnection");
//var connectionString = connectionStrings.GetValue<string>("DefaultConnection");
//var keyJwt = config.GetValue<string>("JwtKey");
var keyJwt = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SectionSecurity")["JwtKey"];
UtilsSecurity.JWT_KEY = keyJwt;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

ConfigureMVC(builder);
ConfigureAuthentication(builder);
ConfigureData(builder);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureMVC(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{

    //string key1 = builder.Configuration.GetValue<string>("JwtKey");

    var keyBytes = Encoding.ASCII.GetBytes(UtilsSecurity.JWT_KEY); //(Globals._KeyT);
    builder.Services.AddAuthentication(configure =>
    {
        configure.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        configure.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(autenticacao =>
    {
        autenticacao.RequireHttpsMetadata = false;
        autenticacao.SaveToken = true;
        autenticacao.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    builder.Services.AddCors();
    //Globals._KeyT = key1;
}




void ConfigureData(WebApplicationBuilder builder)
{
    var connString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(connString);
    });

    /*MYSQL
    
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });
    */

    /* PostGrees
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//Configuration["dbContextSettings:ConnectionString"];
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(connectionString)
    );
    */
    //builder.Services.AddTransient<TokenService>();

    builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();;
    builder.Services.AddScoped<IRoleRepository, RoleRepositoryImpl>();
}







/*
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
*/