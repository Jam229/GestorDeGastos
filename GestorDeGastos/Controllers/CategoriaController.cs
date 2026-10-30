using Microsoft.AspNetCore.Mvc;
using GestorDeGastos.Models;
using GestorDeGastos.Services;


namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private CategoriaService _service;

        public CategoriaController()
        {
            this._service = new CategoriaService();
        }


        // GET: api/<CategoriaController>
        [HttpGet]
        public List<Categoria> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public int Post([FromBody] Categoria categoria)
        {
           return this._service.Crear(categoria);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Categoria categoria)
        {
            categoria.Id = id;
            return this._service.Actualizar(categoria);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
