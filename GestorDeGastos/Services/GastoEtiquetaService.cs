using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class GastoEtiquetaService
    {
        private readonly GastoEtiquetaRepository _repository;

        public GastoEtiquetaService()
        {
            _repository = new GastoEtiquetaRepository();
        }

        public int AsignarEtiqueta(GastoEtiqueta gastoEtiqueta)
        {
            return _repository.Crear(gastoEtiqueta);
        }
    }
}
