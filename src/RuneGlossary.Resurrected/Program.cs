using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Application.Performers;
using RuneGlossary.Resurrected.Infrastructure;
using Serilog;
using STrain.CQS.NetCore;
using STrain.CQS.NetCore.Builders;
using STrain.CQS.NetCore.LigtInject;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLightInject();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IValidator<GetRuneWordsQuery>, GetRuneWordsQueryValidator>();

builder.AddCQS(builder =>
{
    builder.AddPerformerFrom<RunePerformers>();

    builder.AddRequestValidator()
        .UseFluentRequestValidator(builder => { });

    builder.AddMvcRequestReceiver()
        .UseLogger();

    builder.AddGenericRequestHandler();

});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration["Database"]));

var app = builder.Build();

app.UseDefaultExceptionHandler();

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