using RPSLS.API.Common.Mappers;
using RPSLS.Application.Choices.Queries.Common;
using RPSLS.Application.Choices.Queries.GetAllChoices;
using RPSLS.Application.WinnerCalculations;
using RPSLS.Application.WinnerCalculations.Implementation;
using RPSLS.Data.Extensions;
using RPSLS.Infrastructure.Clients.CodeChallenge;
using FluentValidation;
using RPSLS.API.Requests.Choices.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllChoicesQuery).Assembly));
builder.Services.AddServiceDataLayer(builder.Configuration);
builder.Services.AddAutoMapper(typeof(GetAllChoicesProfileMapper));
builder.Services.AddAutoMapper(typeof(ChoicesProfileMapper));
builder.Services.AddTransient<ICodeChallengeApiClient, CodeChallengeApiClient>();
builder.Services.AddTransient<IWinnerCalculation, WinnerCalculation>();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<AddChoiceRequestValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "DefaultCORSPolicy",
        policy =>
        {
            policy.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin();
        });
}); 
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("DefaultCORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
