namespace GestorDeGastos.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int UsuarioId { get; set; }

        public Cuenta(int id, string nombre, string numeroCuenta, decimal saldo, int usuarioId)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.NumeroCuenta = numeroCuenta;
            this.Saldo = saldo;
            this.UsuarioId = usuarioId;
        }
    }
}
