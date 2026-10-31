using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class ReporteService
    {
        private readonly ReporteRepository _repository;

        public ReporteService()
        {
            _repository = new ReporteRepository();
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
    }
}