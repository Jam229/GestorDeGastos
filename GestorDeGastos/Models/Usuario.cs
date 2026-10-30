namespace GestorDeGastos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string ContrasenaHash { get; set; }


        public Usuario(int id, string nombre, string apellido, string documento, string contrasenaHash)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Documento = documento;
            this.ContrasenaHash = contrasenaHash;
        }
    }
}
