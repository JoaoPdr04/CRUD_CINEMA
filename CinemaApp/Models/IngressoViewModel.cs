namespace CinemaApp.Models;

public class IngressoViewModel
{
    public int Id { get; set; }
    public int SessaoId { get; set; }
    public string Filme { get; set; } = string.Empty;
    public string Classificacao { get; set; } = string.Empty;
    public string FormaPagamento { get; set; } = string.Empty;
    public DateTime DataCompra { get; set; }
    public decimal ValorTotal { get; set; }
}
