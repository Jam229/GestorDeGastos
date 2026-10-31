using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;
        private readonly HashService _hashService;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
            _hashService = new HashService();
        }

        public bool VerificarContrasena(string documento, string contrasena)
        {
            Usuario? usuario = _repository.ObtenerPorDocumento(documento);

            if (usuario == null)
            {
                return false;
            }

            return _hashService.Verificar(contrasena, usuario.ContrasenaHash);
        }

        public int Crear(Usuario usuario)
        {
            usuario.ContrasenaHash = _hashService.Hashear(usuario.ContrasenaHash);
            return _repository.Crear(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> usuarios = _repository.ObtenerTodos();

            foreach (Usuario usuario in usuarios)
            {
                usuario.ContrasenaHash = string.Empty;
            }

            return usuarios;
        }

        public Usuario? ObtenerPorId(int id)
        {
            Usuario? usuario = _repository.ObtenerPorId(id);

            if (usuario != null)
            {
                usuario.ContrasenaHash = string.Empty;
            }

            return usuario;
        }

        public bool Actualizar(Usuario usuario)
        {
            usuario.ContrasenaHash = _hashService.Hashear(usuario.ContrasenaHash);
            return _repository.Actualizar(usuario);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
