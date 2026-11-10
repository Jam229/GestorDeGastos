using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class GastoRepository
    {
        private readonly string _connectionString;
        public GastoRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
  
        public int Crear(Gasto gasto)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO gasto (Descripcion, Valor, Fecha, MetodoPagoId, CategoriaId, CuentaId)
                VALUES (@Descripcion, @Valor, @Fecha, @MetodoPagoId, @CategoriaId, @CuentaId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
            command.Parameters.AddWithValue("@Valor", gasto.Valor);
            command.Parameters.AddWithValue("@Fecha", gasto.Fecha);
            command.Parameters.AddWithValue("@MetodoPagoId", gasto.MetodoPagoId);
            command.Parameters.AddWithValue("@CategoriaId", gasto.CategoriaId);
            command.Parameters.AddWithValue("@CuentaId", gasto.CuentaId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
      

        public List<Gasto> ObtenerTodos()
        {
            var gastos = new List<Gasto>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Descripcion, Valor, Fecha, MetodoPagoId, CategoriaId, CuentaId
                FROM gasto;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var gasto = new Gasto(
                        reader.GetInt32("Id"),
                        reader.GetString("Descripcion"),
                        reader.GetDecimal("Valor"),
                        reader.GetDateTime("Fecha"),
                        reader.GetInt32("MetodoPagoId"),
                        reader.GetInt32("CategoriaId"),
                        reader.GetInt32("CuentaId")
                );

                gastos.Add(gasto);
            }
            return gastos;
        }

     

        public Gasto? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Descripcion, Valor, Fecha, MetodoPagoId, CategoriaId, CuentaId
            FROM gasto
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Gasto(
                        reader.GetInt32("Id"),
                        reader.GetString("Descripcion"),
                        reader.GetDecimal("Valor"),
                        reader.GetDateTime("Fecha"),
                        reader.GetInt32("MetodoPagoId"),
                        reader.GetInt32("CategoriaId"),
                        reader.GetInt32("CuentaId")
                    );
            }

            return null;
        }
      
        public bool Actualizar(Gasto gasto)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE gasto
            SET
                Descripcion = @Descripcion,
                Valor = @Valor,
                Fecha = @Fecha,
                MetodoPagoId = @MetodoPagoId,
                CategoriaId = @CategoriaId,
                CuentaId = @CuentaId
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", gasto.Id);
            command.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
            command.Parameters.AddWithValue("@Valor", gasto.Valor);
            command.Parameters.AddWithValue("@Fecha", gasto.Fecha);
            command.Parameters.AddWithValue("@MetodoPagoId", gasto.MetodoPagoId);
            command.Parameters.AddWithValue("@CategoriaId", gasto.CategoriaId);
            command.Parameters.AddWithValue("@CuentaId", gasto.CuentaId);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

     
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM gasto
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
