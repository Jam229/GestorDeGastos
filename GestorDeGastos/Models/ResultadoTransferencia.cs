namespace GestorDeGastos.Models
{
    public class ResultadoTransferencia
    {
        public bool Exitosa { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public decimal SaldoOrigen { get; set; }
        public decimal SaldoDestino { get; set; }
    }
}