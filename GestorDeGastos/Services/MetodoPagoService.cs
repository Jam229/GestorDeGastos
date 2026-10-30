using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class MetodoPagoService
    {
        private readonly MetodoPagoRepository _repository;

        public MetodoPagoService()
        {
            _repository = new MetodoPagoRepository();
        }

        public int Crear(MetodoPago metodoPago)
        {
            return _repository.Crear(metodoPago);
        }

        public List<MetodoPago> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public MetodoPago? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(MetodoPago metodoPago)
        {
            return _repository.Actualizar(metodoPago);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
