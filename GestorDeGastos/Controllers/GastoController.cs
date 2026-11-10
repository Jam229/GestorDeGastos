using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;



namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private GastoService _service;

        public GastoController()
        {
            this._service = new GastoService();
        }


        // GET: api/<GastoController>
        [HttpGet]
        public List<Gasto> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<GastoController>/5
        [HttpGet("{id}")]
        public Gasto? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<GastoController>
        [HttpPost]
        public int Post([FromBody] Gasto gasto)
        {
            return this._service.Crear(gasto);
        }

        // PUT api/<GastoController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Gasto gasto)
        {
            gasto.Id = id;
            return this._service.Actualizar(gasto);
        }

        // DELETE api/<GastoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
