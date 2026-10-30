using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _repository;

        public CategoriaService()
        {
            _repository = new CategoriaRepository();
        }

        public int Crear(Categoria categoria)
        {
            return _repository.Crear(categoria);
        }

        public List<Categoria> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Categoria? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Categoria categoria)
        {
            return _repository.Actualizar(categoria);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}