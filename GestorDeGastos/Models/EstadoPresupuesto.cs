namespace GestorDeGastos.Models
{
    public class EstadoPresupuesto
    {
        public int PresupuestoId { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal ValorLimite { get; set; }
        public decimal TotalGastado { get; set; }
        public decimal Disponible { get; set; }
        public decimal PorcentajeConsumido { get; set; }
        public bool Excedido { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}