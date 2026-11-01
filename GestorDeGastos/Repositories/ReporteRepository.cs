using GestorDeGastos.Models;
using MySqlConnector;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<TotalPorCategoria> ObtenerGastosPorCategoria(int usuarioId, DateTime desde, DateTime hasta)
        {
            var totalesPorCategoria = new List<TotalPorCategoria>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT cat.Id, cat.Nombre, SUM(g.Valor) AS Total
                FROM gasto g
                INNER JOIN cuenta c ON c.Id = g.CuentaId
                INNER JOIN categoria cat ON cat.Id = g.CategoriaId
                WHERE c.UsuarioId = @UsuarioId
                    AND g.Fecha >= @Desde
                    AND g.Fecha < @Hasta
                GROUP BY cat.Id, cat.Nombre
                ORDER BY Total DESC;
            ";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var totalPorCategoria = new TotalPorCategoria
                {
                    CategoriaId = reader.GetInt32("Id"),
                    Categoria = reader.GetString("Nombre"),
                    Total = reader.GetDecimal("Total")

                };
                totalesPorCategoria.Add(totalPorCategoria);
            }
            return totalesPorCategoria;

        }

        public decimal ObtenerTotalGastosPorCategoria(int usuarioId, int categoriaId, DateTime desde, DateTime hasta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COALESCE(SUM(g.Valor), 0) AS TotalGastado
                FROM gasto g
                INNER JOIN cuenta c ON c.Id = g.CuentaId
                WHERE c.UsuarioId = @UsuarioId
                    AND g.CategoriaId = @CategoriaId
                    AND g.Fecha >= @Desde
                    AND g.Fecha <= @Hasta;
            ";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            command.Parameters.AddWithValue("@CategoriaId", categoriaId);
            command.Parameters.AddWithValue("@Desde", desde);
            command.Parameters.AddWithValue("@Hasta", hasta);

            return Convert.ToDecimal(command.ExecuteScalar());
        }
    }
}
