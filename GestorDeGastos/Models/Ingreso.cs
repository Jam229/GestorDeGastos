namespace GestorDeGastos.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }


        public Ingreso(int id, string descripcion, decimal valor, DateTime fecha, int cuentaId)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Valor = valor;
            this.Fecha = fecha;
            this.CuentaId = cuentaId;
        }
    }
}
