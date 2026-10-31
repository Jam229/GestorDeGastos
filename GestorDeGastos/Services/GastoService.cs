using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class GastoService
    {
        private readonly GastoRepository _repository;

        public GastoService()
        {
            _repository = new GastoRepository();
        }

        public int Crear(Gasto gasto)
        {
            return _repository.Crear(gasto);
        }

        public List<Gasto> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Gasto? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Gasto gasto)
        {
            return _repository.Actualizar(gasto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
