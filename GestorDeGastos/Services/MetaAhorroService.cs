using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class MetaAhorroService
    {
        private readonly MetaAhorroRepository _repository;
        private readonly CuentaService _cuentaService;

        public MetaAhorroService()
        {
            _repository = new MetaAhorroRepository();
            _cuentaService = new CuentaService();
        }

        public int Crear(MetaAhorro metaAhorro)
        {
            if (!EsValido(metaAhorro))
            {
                return 0;
            }
            return _repository.Crear(metaAhorro);
        }

        public List<MetaAhorro> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public MetaAhorro? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(MetaAhorro metaAhorro)
        {
            if (!EsValido(metaAhorro))
            {
                return false;
            }
            return _repository.Actualizar(metaAhorro);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        private bool EsValido(MetaAhorro meta)
        {
            if (string.IsNullOrWhiteSpace(meta.Nombre))
            {
                return false;
            }

            if (meta.MontoObjetivo <= 0 || meta.MontoActual < 0)
            {
                return false;
            }

            if (meta.FechaLimite == default)
            {
                return false;
            }

            if (_cuentaService.ObtenerPorId(meta.CuentaId) == null)
            {
                return false;
            }

            return true;
        }
    }
}
