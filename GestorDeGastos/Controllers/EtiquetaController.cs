using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;


namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        private EtiquetaService _service;

        public EtiquetaController()
        {
            this._service = new EtiquetaService();
        }


        // GET: api/<EtiquetaController>
        [HttpGet]
        public List<Etiqueta> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<EtiquetaController>/5
        [HttpGet("{id}")]
        public Etiqueta? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<EtiquetaController>
        [HttpPost]
        public int Post([FromBody] Etiqueta etiqueta)
        {
            return this._service.Crear(etiqueta);
        }

        // PUT api/<EtiquetaController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Etiqueta etiqueta)
        {
            etiqueta.Id = id;
            return this._service.Actualizar(etiqueta);
        }

        // DELETE api/<EtiquetaController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
