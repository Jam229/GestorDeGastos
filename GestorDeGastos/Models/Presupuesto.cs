namespace GestorDeGastos.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public decimal ValorLimite { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public int CategoriaId { get; set; }
        public int  UsuarioId { get; set; }

        public Presupuesto(int id, decimal valorLimite, DateTime fechaInicio, DateTime fechaFin, int categoriaId, int usuarioId)
        {
            this.Id = id;
            this.ValorLimite = valorLimite;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.CategoriaId = categoriaId;
            this.UsuarioId= usuarioId;
        }
    }
}
