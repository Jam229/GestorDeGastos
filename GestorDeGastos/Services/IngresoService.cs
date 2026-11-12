using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class IngresoService
    {
        private readonly IngresoRepository _repository;
        private readonly CuentaService _cuentaService;

        public IngresoService()
        {
            _repository = new IngresoRepository();
            _cuentaService = new CuentaService();
        }

        public int Crear(Ingreso ingreso)
        {
            if (!EsValido(ingreso))
            {
                return 0;
            }

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
            if (!EsValido(ingreso))
            {
                return false;
            }

            return _repository.Actualizar(ingreso);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        private bool EsValido(Ingreso ingreso)
        {
            if (ingreso.Valor <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(ingreso.Descripcion))
            {
                return false;
            }

            if (ingreso.Fecha == default)
            {
                return false;
            }

            if (_cuentaService.ObtenerPorId(ingreso.CuentaId) == null)
            {
                return false;
            }

            return true;
        }
    }
}