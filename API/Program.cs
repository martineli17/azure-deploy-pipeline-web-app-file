var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/health", () =>
{
    return Results.Ok(new { Health = true });
}).WithName("GetHealth")
  .WithOpenApi(x =>
  {
      x.Description = "Endpoint para health check";

      return x;
  });

app.MapGet("/environment-variable", () =>
{
    return Results.Ok(new { Value = Environment.GetEnvironmentVariable("teste") });
}).WithName("Environmentvariable")
  .WithOpenApi(x =>
  {
      x.Description = "Endpoint para retornar variável de ambiente";

      return x;
  });

app.Run();