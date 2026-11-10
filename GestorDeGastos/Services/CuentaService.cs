using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class CuentaService
    {
        private readonly CuentaRepository _repository;

        public CuentaService()
        {
            _repository = new CuentaRepository();
        }

        public int Crear(Cuenta cuenta)
        {
            return _repository.Crear(cuenta);
        }

        public List<Cuenta> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Cuenta? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Cuenta cuenta)
        {
            return _repository.Actualizar(cuenta);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        public bool Transferir(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            return _repository.Transferir(cuentaOrigenId, cuentaDestinoId, monto);
        }
    }
}
