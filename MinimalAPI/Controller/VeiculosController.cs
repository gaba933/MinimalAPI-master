using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entidades;
using MinimalAPI.Interfaces;
using MinimalAPI.Db;

namespace MinimalAPI.Controller;

public class VeiculosController: IVeiculosController
{
    private readonly DbMinimalAPI _contexto;
    public VeiculosController(DbMinimalAPI contexto)
    {
        _contexto = contexto;
    }
    
    public List<Veiculos> Todos( string? Nome = null, string? Marca = null, string? Ano = null, int? pagina = 1)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(Nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{Nome}%"));
        }

        int itens = 10;
        
        if(pagina != null)
            query = query.Skip(((int)pagina - 1) * itens).Take(itens);

        return query.ToList();
    }

    public Veiculos? BuscarPorId(int id)
    {
        return _contexto.Veiculos.Find(id);
    }

    public void Incluir(Veiculos veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public void Alterar(Veiculos veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
            
        
    }

    public void Excluir(Veiculos veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }
}