namespace GestorDeGastos.Models
{
    public class BalanceMensual
    {
        public int UsuarioId { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal Balance { get; set; }
    }
}
