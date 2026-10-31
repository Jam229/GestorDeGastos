using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class PresupuestoService
    {
        private readonly PresupuestoRepository _repository;

        public PresupuestoService()
        {
            _repository = new PresupuestoRepository();
        }

        public int Crear(Presupuesto presupuesto)
        {
            return _repository.Crear(presupuesto);
        }

        public List<Presupuesto> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Presupuesto? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Presupuesto presupuesto)
        {
            return _repository.Actualizar(presupuesto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
