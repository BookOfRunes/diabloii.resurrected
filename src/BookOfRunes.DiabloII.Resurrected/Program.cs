using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Application.Contexts;
using BookOfRunes.DiabloII.Resurrected.Application.Performers;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using STrain.CQS.NetCore;
using STrain.CQS.NetCore.Builders;
using STrain.CQS.NetCore.LigtInject;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLightInject();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication()
	.AddJwtBearer(options =>
	{
		options.MetadataAddress = "https://login.microsoftonline.com/3e56baf4-8b33-4eac-abc7-fe892bc17c68/v2.0/.well-known/openid-configuration";
		options.TokenValidationParameters.ValidateAudience = false;
	});

builder.Services.AddScoped<IValidator<GetRuneWordsQuery>, GetRuneWordsQueryValidator>();

builder.AddCQS(builder =>
{
	builder.AddPerformersFrom<RunePerformers>();

	builder.AddRequestValidator()
		.UseFluentRequestValidator(_ => { });

	builder.AddMvcRequestReceiver()
		.UseLogger()
		.UseAuthorization();

	builder.AddGenericRequestHandler();
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration["Database"]));

builder.Services.AddScoped<IUserContext, UserContext>();

var app = builder.Build();

//app.UseExceptionHandler();
app.UseCors(builder =>
{
	builder.AllowAnyMethod();
	builder.AllowAnyHeader();
	builder.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGenericRequestController();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
	db.Database.Migrate();
}

app.Run();