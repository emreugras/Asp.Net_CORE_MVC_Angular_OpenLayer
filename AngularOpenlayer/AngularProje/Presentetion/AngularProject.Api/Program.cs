using AngularProject.Persistence;
using AngularProject.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",Options =>
{
	Options.TokenValidationParameters = new()
	{
		ValidateAudience = true,
		ValidateIssuer = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,

		ValidAudience = builder.Configuration["Token:Audience"],
		ValidIssuer = builder.Configuration["Token:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
			builder.Configuration["Token:SecurityKey"]))
	};
});
//builder.Services.AddAuthorization(Options =>
//{
//	Options.AddPolicy("Admin", policy =>
//	{
//		policy.RequireRole("Admin");
//	});
//});
// Add services to the container.
builder.Services.AddPersistanceService();
var Configuration = builder.Configuration;
//builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
//builder.Services.AddDbContext<LoggerDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
var app = builder.Build();
//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Table>(opt=>opt.UseNpgsql(ConfigurationBu))

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.UseSession();

app.MapControllers();

app.Run();
