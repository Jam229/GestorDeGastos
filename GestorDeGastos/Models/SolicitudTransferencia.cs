namespace GestorDeGastos.Models
{
    public class SolicitudTransferencia
    {
        public int CuentaOrigenId { get; set; }
        public int CuentaDestinoId { get; set; }
        public decimal Monto { get; set; }
    }
}