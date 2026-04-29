namespace MinimalAPI.Models;
using MinimalAPI.Enuns;

public class AdmDTO
{
    public string Email { get;set; } = default!;
    public string Senha { get;set; } = default!;
    public Perfil? Perfil { get;set; } = default!;
}