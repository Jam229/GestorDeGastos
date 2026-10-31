using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDePresupuestos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private PresupuestoService _service;

        public PresupuestoController()
        {
            this._service = new PresupuestoService();
        }


        // GET: api/<PresupuestoController>
        [HttpGet]
        public List<Presupuesto> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<PresupuestoController>/5
        [HttpGet("{id}")]
        public Presupuesto? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<PresupuestoController>
        [HttpPost]
        public int Post([FromBody] Presupuesto presupuesto)
        {
            return this._service.Crear(presupuesto);
        }

        // PUT api/<PresupuestoController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Presupuesto presupuesto)
        {
            presupuesto.Id = id;
            return this._service.Actualizar(presupuesto);
        }

        // DELETE api/<PresupuestoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
