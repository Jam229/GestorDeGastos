using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class MetaAhorroService
    {
        private readonly MetaAhorroRepository _repository;

        public MetaAhorroService()
        {
            _repository = new MetaAhorroRepository();
        }

        public int Crear(MetaAhorro metaAhorro)
        {
            return _repository.Crear(metaAhorro);
        }

        public List<MetaAhorro> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public MetaAhorro? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Actualizar(MetaAhorro metaAhorro)
        {
            return _repository.Actualizar(metaAhorro);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
