using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {
        private IngresoService _service;

        public IngresoController()
        {
            this._service = new IngresoService();
        }


        // GET: api/<IngresoController>
        [HttpGet]
        public List<Ingreso> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<IngresoController>/5
        [HttpGet("{id}")]
        public Ingreso? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<IngresoController>
        [HttpPost]
        public int Post([FromBody] Ingreso ingreso)
        {
            return this._service.Crear(ingreso);
        }

        // PUT api/<IngresoController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Ingreso ingreso)
        {
            ingreso.Id = id;
            return this._service.Actualizar(ingreso);
        }

        // DELETE api/<IngresoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
