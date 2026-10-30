using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
        }

        public int Crear(Usuario usuario)
        {
            return _repository.Crear(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Usuario usuario)
        {
            return _repository.Actualizar(usuario);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
