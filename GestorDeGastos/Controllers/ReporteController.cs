using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ReporteService _service;


        public ReporteController()
        {
            _service = new ReporteService();
        }

        // GET: api/Reporte/balance?usuarioId=2&anio=2026&mes=10
        [HttpGet("balance")]
        public BalanceMensual Balance([FromQuery] int usuarioId, [FromQuery] int anio, [FromQuery] int mes)
        {
            return _service.ObtenerBalanceMensual(usuarioId, anio, mes);
        }

        // GET: api/Reporte/gastos-por-categoria?usuarioId=2&anio=2026&mes=10
        [HttpGet("gastos-por-categoria")]
        public List<TotalPorCategoria> GastosPorCategoria([FromQuery] int usuarioId, [FromQuery] int anio, [FromQuery] int mes)
        {
            return _service.ObtenerGastosPorCategoria(usuarioId, anio, mes);
        }
    }

}
