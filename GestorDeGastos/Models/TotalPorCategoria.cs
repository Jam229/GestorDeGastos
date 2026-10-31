namespace GestorDeGastos.Models
{
    public class TotalPorCategoria
    {
        public int CategoriaId { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
