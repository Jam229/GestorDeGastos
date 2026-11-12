using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class GastoService
    {
        private readonly GastoRepository _repository;
        private readonly CuentaService _cuentaService;
        private readonly CategoriaService _categoriaService;
        private readonly MetodoPagoService _metodoPagoService;

        public GastoService()
        {
            _repository = new GastoRepository();
            _repository = new GastoRepository();
            _cuentaService = new CuentaService();
            _categoriaService = new CategoriaService();
            _metodoPagoService = new MetodoPagoService();
        }

        public int Crear(Gasto gasto)
        {
            if (!EsValido(gasto))
            {
                return 0;
            }
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
            if (!EsValido(gasto))
            {
                return false;
            }
            return _repository.Actualizar(gasto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        private bool EsValido(Gasto gasto)
        {
            if (gasto.Valor <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(gasto.Descripcion))
            {
                return false;
            }

            if (gasto.Fecha == default)
            {
                return false;
            }

            if (_cuentaService.ObtenerPorId(gasto.CuentaId) == null
                || _categoriaService.ObtenerPorId(gasto.CategoriaId) == null
                || _metodoPagoService.ObtenerPorId(gasto.MetodoPagoId) == null)
            {
                return false;
            }

            return true;
        }
    }
}
