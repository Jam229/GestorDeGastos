
namespace GestorDeGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int MetodoPagoId { get; set; }
        public int CategoriaId { get; set; }
        public int CuentaId { get; set; }


        public Gasto(int id, string descripcion, decimal valor, DateTime fecha, int metodoPagoId, int categoriaId, int cuentaId) 
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Valor = valor;
            this.Fecha = fecha;
            this.MetodoPagoId = metodoPagoId;
            this.CategoriaId = categoriaId;
            this.CuentaId = cuentaId;
        }

    }
}
