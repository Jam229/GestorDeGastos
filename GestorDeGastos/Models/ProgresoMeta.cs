namespace GestorDeGastos.Models
{
    public class ProgresoMeta
    {
        public int MetaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal MontoObjetivo { get; set; }
        public decimal MontoActual { get; set; }
        public decimal MontoFaltante { get; set; }
        public decimal PorcentajeAvance { get; set; }
        public bool Cumplida { get; set; }
    }
}
