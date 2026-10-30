using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class EtiquetaService
    {
        private readonly EtiquetaRepository _repository;

        public EtiquetaService()
        {
            _repository = new EtiquetaRepository();
        }

        public int Crear(Etiqueta etiqueta)
        {
            return _repository.Crear(etiqueta);
        }

        public List<Etiqueta> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Etiqueta? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(Etiqueta etiqueta)
        {
            return _repository.Actualizar(etiqueta);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
