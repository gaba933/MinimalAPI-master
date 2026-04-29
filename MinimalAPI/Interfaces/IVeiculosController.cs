using MinimalAPI.Entidades;

namespace MinimalAPI.Interfaces;

public interface IVeiculosController
{
    List<Veiculos> Todos( string? Nome, string? Marca, string? Ano, int? pagina = 1 );
    Veiculos? BuscarPorId(int id);
    void Incluir(Veiculos veiculo);
    void Alterar(Veiculos veiculo);
    void Excluir(Veiculos veiculo);
}