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

// ─────────────────────────────────────────────
// 🚀 1. Add Controllers and FluentValidation
// ─────────────────────────────────────────────
builder.Services.AddControllers(); // No usamos .AddFluentValidation() porque es obsoleto
builder.Services.AddValidatorsFromAssemblyContaining<CreateObjectCommandValidator>();

// ─────────────────────────────────────────────
// 🔧 2. Swagger / OpenAPI
// ─────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ─────────────────────────────────────────────
// 🔌 3. Dependency Injection - Application Services
// ─────────────────────────────────────────────
builder.Services.AddHttpClient<IRestfulApiService, RestfulApiService>();
builder.Services.AddHttpClient<IRandomUserService, RandomUserService>();


builder.Services.AddMediatR(typeof(GetAllObjectsQueryHandler).Assembly);

// 📌 3.1 Pipeline behavior to validate commands/queries automatically
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddAutoMapper(typeof(ObjectProfile).Assembly);

var app = builder.Build();

// ─────────────────────────────────────────────
// 🌐 4. Middleware configuration
// ─────────────────────────────────────────────
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
