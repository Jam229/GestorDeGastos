using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private MetodoPagoService _service;

        public MetodoPagoController()
        {
            this._service = new MetodoPagoService();
        }


        // GET: api/<MetodoPagoController>
        [HttpGet]
        public List<MetodoPago> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<MetodoPagoController>/5
        [HttpGet("{id}")]
        public MetodoPago? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<MetodoPagoController>
        [HttpPost]
        public int Post([FromBody] MetodoPago metodoPago)
        {
            return this._service.Crear(metodoPago);
        }

        // PUT api/<MetodoPagoController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] MetodoPago metodoPago)
        {
            metodoPago.Id = id;
            return this._service.Actualizar(metodoPago);
        }

        // DELETE api/<MetodoPagoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
