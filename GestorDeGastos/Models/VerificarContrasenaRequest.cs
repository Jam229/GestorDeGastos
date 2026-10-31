namespace GestorDeGastos.Models
{
    public class VerificarContrasenaRequest
    {
        public string Documento { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
