using Prometheus;
using RPSLS.API.Common.Mappers;
using RPSLS.Application.Choices.Queries.GetAllChoices;
using RPSLS.Data.Extensions;


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
builder.Services.AddAutoMapper(typeof(ChoicesProfileMapper));
//builder.Services.AddAutoMapper(typeof(ChoiceProfileMapper));

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

app.UseMetricServer(); //default metrics set up by prometheus-net(navigate to /metrics)

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
