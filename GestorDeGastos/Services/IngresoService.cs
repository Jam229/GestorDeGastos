using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class IngresoService
    {
        private readonly IngresoRepository _repository;

        public IngresoService()
        {
            _repository = new IngresoRepository();
        }

        public int Crear(Ingreso ingreso)
        {
            return _repository.Crear(ingreso);
        }

        public List<Ingreso> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Ingreso? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Ingreso ingreso)
        {
            return _repository.Actualizar(ingreso);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
