using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class GastoEtiquetaRepository
    {
        private readonly string _connectionString;

        public GastoEtiquetaRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }


        public int Crear(GastoEtiqueta gastoEtiqueta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO gasto_etiqueta (GastoId, EtiquetaId)
                VALUES (@GastoId, @EtiquetaId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GastoId", gastoEtiqueta.GastoId);
            command.Parameters.AddWithValue("@EtiquetaId", gastoEtiqueta.EtiquetaId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
    }
}