namespace GestorDeGastos.Models
{
    public class MetodoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public MetodoPago(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
