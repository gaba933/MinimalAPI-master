using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Entidades;

public class Veiculos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(155)]
    public string Marca { get; set; }
    
    [Required]
    public int  Ano { get; set; }
    
}