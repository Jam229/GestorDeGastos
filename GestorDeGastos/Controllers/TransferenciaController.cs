using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {

        private readonly TransferenciaService _transferenciaService;

        public TransferenciaController()
        {
            _transferenciaService = new TransferenciaService();
        }

        // POST: api/Transferencia
        [HttpPost]
        public ResultadoTransferencia Post([FromBody] SolicitudTransferencia solicitud)
        {
            return _transferenciaService.Transferir(solicitud);
        }
    }
}
