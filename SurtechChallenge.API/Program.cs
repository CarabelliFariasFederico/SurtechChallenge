using FluentValidation;
using MediatR;
using SurtechChallenge.API.Middlewares;
using SurtechChallenge.Application.Common.Behaviors;
using SurtechChallenge.Application.Features.Objects.Queries;
using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Application.Mappings;
using SurtechChallenge.Application.Validators;
using SurtechChallenge.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//  Registrar validadores con FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateObjectCommandValidator>();

//  Registrar AutoMapper con perfiles de mapeo
builder.Services.AddAutoMapper(typeof(ObjectProfile).Assembly);

//  Registrar servicios HTTP (RESTful API + RandomUser API)
builder.Services.AddHttpClient<IRestfulApiService, RestfulApiService>();
builder.Services.AddHttpClient<IRandomUserService, RandomUserService>();

// 📌 Registrar MediatR para CQRS
builder.Services.AddMediatR(typeof(GetAllObjectsQueryHandler).Assembly);

//  Pipeline de validación (Behavior que intercepta y lanza errores si hay fallos)
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//  Middleware global de manejo de excepciones (validaciones y errores 500)
app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
