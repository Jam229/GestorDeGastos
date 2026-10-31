namespace GestorDeGastos.Models
{
    public class MetaAhorro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal MontoObjetivo { get; set; }
        public decimal MontoActual { get; set; }
        public DateTime FechaLimite { get; set; }
        public int CuentaId { get; set; }

        public MetaAhorro(int id, string nombre, decimal montoObjetivo, decimal montoActual, DateTime fechaLimite, int cuentaId)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.MontoObjetivo = montoObjetivo;
            this.MontoActual = montoActual;
            this.FechaLimite = fechaLimite;
            this.CuentaId = cuentaId;
        }
    }
}
