using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController()
        {
            this._service = new UsuarioService();
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public int Post([FromBody] Usuario usuario)
        {
            return this._service.Crear(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Usuario usuario)
        {
            usuario.Id = id;
            return this._service.Actualizar(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
