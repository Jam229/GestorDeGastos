using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class PresupuestoService
    {
        private readonly PresupuestoRepository _repository;
        private readonly CategoriaService _categoriaService;
        private readonly UsuarioService _usuarioService;

        public PresupuestoService()
        {
            _repository = new PresupuestoRepository();
            _categoriaService = new CategoriaService();
            _usuarioService = new UsuarioService();
        }

        public int Crear(Presupuesto presupuesto)
        {
            if (!EsValido(presupuesto))
            {
                return 0;
            }
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
            if (!EsValido(presupuesto))
            {
                return false;
            }
            return _repository.Actualizar(presupuesto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        private bool EsValido(Presupuesto presupuesto)
        {
            if (presupuesto.ValorLimite <= 0)
            {
                return false;
            }

            if (presupuesto.FechaInicio == default || presupuesto.FechaFin == default)
            {
                return false;
            }

            if (presupuesto.FechaFin < presupuesto.FechaInicio)
            {
                return false;
            }

            if (_categoriaService.ObtenerPorId(presupuesto.CategoriaId) == null
                || _usuarioService.ObtenerPorId(presupuesto.UsuarioId) == null)
            {
                return false;
            }

            return true;
        }
    }
}
