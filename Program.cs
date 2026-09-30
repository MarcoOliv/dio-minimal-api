using MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var veiculos = new List<Veiculo>
{
    new Veiculo { Id = 1, Marca = "Honda", Modelo = "Civic", Ano = 2020 },
    new Veiculo { Id = 2, Marca = "Toyota", Modelo = "Corolla", Ano = 2022 }
};

app.MapGet("/", () => new
{
    Message = "API funcionando"
});

app.MapGet("/veiculos", () =>
{
    return veiculos;
});

app.MapGet("/veiculos/{id}", (int id) =>
{
    var veiculo = veiculos.FirstOrDefault(v => v.Id == id);
    return veiculo is not null ? Results.Ok(veiculo) : Results.NotFound();
});

a´pp.MapPost("/veiculos", (Veiculo veiculo) =>
{
    veiculo.Id = veiculos.Count + 1;
    veiculos.Add(veiculo);
    return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
});

app.Run();
