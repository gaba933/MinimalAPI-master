using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Controller;
using MinimalAPI.Db;
using MinimalAPI.Entidades;
using MinimalAPI.Enuns;
using MinimalAPI.Interfaces;
using MinimalAPI.MenusModels;
using MinimalAPI.Models;


#region Builder

var builder = WebApplication.CreateBuilder(args);

var Key = builder.Configuration.GetSection("Jwt").ToString();
if (string.IsNullOrEmpty(Key)) 
    Key = "123456";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAdmController, AdministradorController>();
builder.Services.AddScoped<IVeiculosController, VeiculosController>();
builder.Services.AddDbContext<DbMinimalAPI>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#endregion

#region Home
app.MapGet("/", () => Results.Json(new Home())).WithTags("HOME");
#endregion

#region Adms
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDto, IAdmController AdministradorController) =>
{
    if (AdministradorController.Login(loginDto) != null)
        return Results.Ok("Success");
    
    else
        return Results.Unauthorized();
    
}).WithTags("ADM");

app.MapPost("/administradores", ([FromBody] AdmDTO admDTO, IAdmController AdministradorController) =>
{
    if (admDTO == null)
        return Results.Unauthorized();
    var administrador = new Administrador
    {
        Email =  admDTO.Email,
        Senha = admDTO.Senha,
        Perfil = admDTO.Perfil.ToString() ?? Perfil.Editor.ToString()
    };
    
    AdministradorController.Incluir(administrador);
    
    return Results.Ok("Success");

}).RequireAuthorization().WithTags("ADM");

app.MapGet("/administradores", ([FromQuery] int? pagina, IAdmController AdministradorController) =>
{
    var adms = AdministradorController.Listar(pagina);
    return Results.Ok(adms);
}).RequireAuthorization().WithTags("ADM");

app.MapGet("/administradores{id}", ([FromQuery] int id, IAdmController AdministradorController) =>
{
    var adm = AdministradorController.BuscaPorId(id);

    return Results.Ok(adm);
}).RequireAuthorization().WithTags("ADM");
#endregion

#region Veiculos

app.MapPost("/veiculos", ([FromBody] VeiculosDTO VeiculosDTO, IVeiculosController VeiculosController) =>
{
    var veiculo = new Veiculos
    {
        Nome = VeiculosDTO.Nome,
        Marca = VeiculosDTO.Marca,
        Ano = VeiculosDTO.Ano,
    };
   VeiculosController.Incluir(veiculo);
   
   return  Results.Created($"/veiculos/{veiculo.Id}", veiculo); 
}).RequireAuthorization().WithTags("Veiculos");

app.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculosController VeiculosController) =>
{
    var veiculos = VeiculosController.Todos( null, null, null, pagina);
    return Results.Ok(veiculos);
}).RequireAuthorization().WithTags("Veiculos");

app.MapGet("/veiculos/{id}", ([FromQuery] int id, IVeiculosController VeiculosController ) =>
{
    var veiculo = VeiculosController.BuscarPorId(id);
    
    if (veiculo != null)
        return Results.Ok(veiculo);
    else
        return Results.NotFound();
    
}).RequireAuthorization().WithTags("Veiculos");

app.MapPut("/veiculos/{id}", ([FromRoute]int id, VeiculosDTO veiculosDTO, IVeiculosController VeiculosController) =>
{
    var veiculo = VeiculosController.BuscarPorId(id);
    
    if (veiculo == null)
        return Results.NotFound();
    
    veiculo.Nome = veiculosDTO.Nome;
    veiculo.Marca = veiculosDTO.Marca;
    veiculo.Ano = veiculosDTO.Ano;
    VeiculosController.Alterar(veiculo);
    
    return  Results.Created($"/veiculos/{veiculo.Id}", veiculo); 
}).RequireAuthorization().WithTags("Veiculos");

app.MapDelete("/veiculos/{id}", (int id, IVeiculosController VeiculosController) =>
{
    var veiculo = VeiculosController.BuscarPorId(id);
    VeiculosController.Excluir(veiculo);
    
    return Results.NoContent();
});
#endregion

#region App

if (app.Environment.IsDevelopment())
    app.UseSwagger(); app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
#endregion



app.Run();