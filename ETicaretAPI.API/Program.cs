using ETicaretAPI.Application.Validators.Product;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistance;
using ETicaretAPI.Persistance.Contexts;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(configure=>configure.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    //.net core filtremeyi üstteki komut sayesinde controllera gelmeden yapar,alttaki kod satýrý ile controllera gider filtrelemeyi bize býrakýr.
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddPersistanceServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
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

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();

app.MapControllers();

app.Run();
