using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class ReporteRepository
    {
        private readonly string _connectionString;

        public ReporteRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }

        public decimal ObtenerTotalIngresos(int usuarioId, DateTime desde, DateTime hasta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COALESCE(SUM(i.Valor), 0)
                FROM ingreso i
                INNER JOIN cuenta c ON c.Id = i.CuentaId
                WHERE c.UsuarioId = @UsuarioId
                  AND i.Fecha >= @Desde
                  AND i.Fecha < @Hasta;
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            return Convert.ToDecimal(command.ExecuteScalar());
        }

        public decimal ObtenerTotalGastos(int usuarioId, DateTime desde, DateTime hasta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COALESCE(SUM(g.Valor), 0)
                FROM gasto g
                INNER JOIN cuenta c ON c.Id = g.CuentaId
                WHERE c.UsuarioId = @UsuarioId
                  AND g.Fecha >= @Desde
                  AND g.Fecha < @Hasta;
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            return Convert.ToDecimal(command.ExecuteScalar());
        }
    }
}
