using GestorDeGastos.Models;
using GestorDeGastos.Services;
using Microsoft.AspNetCore.Mvc;



namespace GestorDeGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private CuentaService _service;

        public CuentaController()
        {
            this._service = new CuentaService();
        }


        // GET: api/<CuentaController>
        [HttpGet]
        public List<Cuenta> Get()
        {
            return this._service.ObtenerTodos();
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public Cuenta? Get(int id)
        {
            return this._service.ObtenerPorId(id);
        }

        // GET: api/Cuenta/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public List<Cuenta> GetPorUsuario(int usuarioId)
        {
            return _service.ObtenerPorUsuario(usuarioId);
        }

        // POST api/<CuentaController>
        [HttpPost]
        public int Post([FromBody] Cuenta cuenta)
        {
            return this._service.Crear(cuenta);
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Cuenta cuenta)
        {
            cuenta.Id = id;
            return this._service.Actualizar(cuenta);
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._service.Eliminar(id);
        }
    }
}
