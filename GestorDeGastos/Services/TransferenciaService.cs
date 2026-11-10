using GestorDeGastos.Models;
using GestorDeGastos.Repositories;

namespace GestorDeGastos.Services
{
    public class TransferenciaService
    {
        private readonly CuentaService _cuentaService;

        public TransferenciaService()
        {
            _cuentaService = new CuentaService();
        }
        public ResultadoTransferencia Fallo(string mensaje)
        {
            return new ResultadoTransferencia
            {
                Exitosa = false,
                Mensaje = mensaje
            };
        }
        public ResultadoTransferencia Transferir(SolicitudTransferencia solicitud)
        {
            
            
            if(solicitud.Monto <= 0)
            {
                return Fallo("El monto debe ser mayor que 0");
            }

            

            if (solicitud.CuentaOrigenId == solicitud.CuentaDestinoId)
            {
                return Fallo("La cuenta de origen y destino deben ser distintas");
            }
           
            Cuenta? origen = _cuentaService.ObtenerPorId(solicitud.CuentaOrigenId);
            Cuenta? destino = _cuentaService.ObtenerPorId(solicitud.CuentaDestinoId);

            if (origen == null || destino == null)
            {
                return Fallo("Alguna de las cuentas no existe.");
            }

           

            if (origen.UsuarioId != destino.UsuarioId)
            {
                return Fallo("Solo es posible transferir entre cuentas del mismo usuario");
            }

           

            if (origen.Saldo < solicitud.Monto)
            {
                return Fallo("Saldo insuficiente en la cuenta de origen.");
            }



            bool exito = _cuentaService.Transferir(
                    solicitud.CuentaOrigenId,
                    solicitud.CuentaDestinoId,
                    solicitud.Monto
                );


            if (!exito)
            {
                return Fallo("No se pudo completar la transferencia.");
            }

            Cuenta? origenActualizada = _cuentaService.ObtenerPorId(solicitud.CuentaOrigenId);
            Cuenta? destinoActualizada = _cuentaService.ObtenerPorId(solicitud.CuentaDestinoId);



            return new ResultadoTransferencia
            {
                Exitosa = true,
                Mensaje = "Transferencia realizada.",
                SaldoOrigen = origenActualizada?.Saldo ?? 0,
                SaldoDestino = destinoActualizada?.Saldo ?? 0
            };

        }
}
}