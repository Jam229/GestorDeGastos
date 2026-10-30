namespace GestorDeGastos.Models
{
    public class Etiqueta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Etiqueta(int id, string nombre) 
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
