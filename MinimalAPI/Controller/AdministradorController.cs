using MinimalAPI.Db;
using MinimalAPI.Entidades;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;

namespace MinimalAPI.Controller;

public class AdministradorController: IAdmController
{
    private readonly DbMinimalAPI _contexto;

    public AdministradorController(DbMinimalAPI contexto)
    {
        _contexto = contexto;
    }
    
    public Administrador? Login(LoginDTO loginDTO)
    {
        var validar = _contexto.Administradors.Where(a => a.Email == loginDTO.email && a.Senha == loginDTO.password).FirstOrDefault();
        return validar;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradors.Add(administrador);
        _contexto.SaveChanges();
        
        return administrador;
    }

    public List<Administrador> Listar(int? pagina)
    {
        var query = _contexto.Administradors.AsQueryable();

        int itensPorPagina = 10;

        if(pagina != null)
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();    
    }

    public Administrador? BuscaPorId(int id)
    {
        var adm = _contexto.Administradors.Where(a => a.Id == id).FirstOrDefault();
        return adm;
    }
}