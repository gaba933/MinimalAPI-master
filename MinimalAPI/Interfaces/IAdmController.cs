using MinimalAPI.Entidades;
using MinimalAPI.Models;

namespace MinimalAPI.Interfaces;

public interface IAdmController
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    List<Administrador>  Listar(int? pagina = 1);
    Administrador? BuscaPorId(int id);
    
}