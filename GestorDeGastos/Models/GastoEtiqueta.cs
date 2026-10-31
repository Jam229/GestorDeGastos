namespace GestorDeGastos.Models
{
    public class GastoEtiqueta
    {
        public int Id { get; set; }
        public int GastoId { get; set; }
        public int EtiquetaId { get; set; }


        public GastoEtiqueta(int id, int gastoId, int etiquetaId)
        {
            this.Id = id;
            this.GastoId = gastoId;
            this.EtiquetaId = etiquetaId;

        }
    }
}
