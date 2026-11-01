using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class ReporteService
    {
        private readonly ReporteRepository _repository;
        private readonly MetaAhorroRepository _metaRepository;
        private readonly PresupuestoRepository _presupuestoRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public ReporteService()
        {
            _repository = new ReporteRepository();

            _metaRepository = new MetaAhorroRepository();

            _presupuestoRepository = new PresupuestoRepository();

            _categoriaRepository = new CategoriaRepository();
            
        }

        public BalanceMensual ObtenerBalanceMensual(int usuarioId, int anio, int mes)
        {
            DateTime desde = new DateTime(anio, mes, 1);
            DateTime hasta = desde.AddMonths(1);

            decimal ingresos = _repository.ObtenerTotalIngresos(usuarioId, desde, hasta);
            decimal gastos = _repository.ObtenerTotalGastos(usuarioId, desde, hasta);

            return new BalanceMensual
            {
                UsuarioId = usuarioId,
                Anio = anio,
                Mes = mes,
                TotalIngresos = ingresos,
                TotalGastos = gastos,
                Balance = ingresos - gastos
            };
        }

        public List<TotalPorCategoria> ObtenerGastosPorCategoria(int usuarioId, int anio, int mes)
        {
            DateTime desde = new DateTime(anio, mes, 1);
            DateTime hasta = desde.AddMonths(1);

            return _repository.ObtenerGastosPorCategoria(usuarioId, desde, hasta);
        }

        public ProgresoMeta? ObtenerProgresoMeta(int metaId)
        {
            MetaAhorro? meta = _metaRepository.ObtenerPorId(metaId);

            if (meta == null)
            {
                return null;
            }

            decimal porcentaje = 0;

            if (meta.MontoObjetivo > 0)
            {
                porcentaje = Math.Round(meta.MontoActual / meta.MontoObjetivo * 100, 2);
            }

            decimal faltante = Math.Max(0m, meta.MontoObjetivo - meta.MontoActual);

            return new ProgresoMeta
            {
                MetaId = meta.Id,
                Nombre = meta.Nombre,
                MontoObjetivo = meta.MontoObjetivo,
                MontoActual = meta.MontoActual,
                MontoFaltante = faltante,
                PorcentajeAvance = porcentaje,
                Cumplida = meta.MontoObjetivo > 0 && meta.MontoActual >= meta.MontoObjetivo
            };
        }

        public EstadoPresupuesto? ObtenerEstadoPresupuesto(int presupuestoId)
        {
            Presupuesto? presupuesto = _presupuestoRepository.ObtenerPorId(presupuestoId);

            if (presupuesto == null)
            {
                return null;
            }

            Categoria? categoria = _categoriaRepository.ObtenerPorId(presupuesto.CategoriaId);

            decimal gastado = _repository.ObtenerTotalGastosPorCategoria(
                presupuesto.UsuarioId,
                presupuesto.CategoriaId,
                presupuesto.FechaInicio,
                presupuesto.FechaFin);

            decimal porcentaje = 0;

            if (presupuesto.ValorLimite > 0)
            {
                porcentaje = Math.Round(gastado / presupuesto.ValorLimite * 100, 2);
            }

            string estado;

            if (gastado > presupuesto.ValorLimite)
            {
                estado = "Excedido";
            }
            else if (presupuesto.ValorLimite > 0 && gastado >= presupuesto.ValorLimite * 0.8m)
            {
                estado = "Cerca del límite";
            }
            else
            {
                estado = "Dentro del límite";
            }

            return new EstadoPresupuesto
            {
                PresupuestoId = presupuesto.Id,
                Categoria = categoria?.Nombre ?? string.Empty,
                FechaInicio = presupuesto.FechaInicio,
                FechaFin = presupuesto.FechaFin,
                ValorLimite = presupuesto.ValorLimite,
                TotalGastado = gastado,
                Disponible = presupuesto.ValorLimite - gastado,
                PorcentajeConsumido = porcentaje,
                Excedido = gastado > presupuesto.ValorLimite,
                Estado = estado
            };
        }

    }
}