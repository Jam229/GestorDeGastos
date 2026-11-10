using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;



namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaAhorroController : ControllerBase
    {
        private MetaAhorroService _service;

        public MetaAhorroController()
        {
            this._service = new MetaAhorroService();
        }


        // GET: api/<MetaAhorroController>
        [HttpGet]
        public List<MetaAhorro> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<MetaAhorroController>/5
        [HttpGet("{id}")]
        public MetaAhorro? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<MetaAhorroController>
        [HttpPost]
        public int Post([FromBody] MetaAhorro metaAhorro)
        {
            return this._service.Crear(metaAhorro);
        }

        // PUT api/<MetaAhorroController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] MetaAhorro metaAhorro)
        {
            metaAhorro.Id = id;
            return this._service.Actualizar(metaAhorro);
        }

        // DELETE api/<MetaAhorroController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
