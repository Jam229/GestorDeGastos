using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;


namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoEtiquetaController : ControllerBase
    {
        private readonly GastoEtiquetaService _service;

        public GastoEtiquetaController()
        {
            _service = new GastoEtiquetaService();
        }

        // POST: api/GastoEtiqueta
        [HttpPost]
        public int Post([FromBody] GastoEtiqueta gastoEtiqueta)
        {
            return _service.AsignarEtiqueta(gastoEtiqueta);
        }
    }
}
