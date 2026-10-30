using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class MetodoPagoRepository
    {
        private readonly string _connectionString;
        public MetodoPagoRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
        //CREATE
        public int Crear(MetodoPago metodoPago)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO metodo_pago (Nombre)
                VALUES (@Nombre);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", metodoPago.Nombre);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        //READ - obtener todos

        public List<MetodoPago> ObtenerTodos()
        {
            var metodosPago = new List<MetodoPago>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre
                FROM metodo_pago;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var metodoPago = new MetodoPago(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                );

                metodosPago.Add(metodoPago);
            }
            return metodosPago;
        }

        //READ - obtener por Id

        public MetodoPago? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre
            FROM metodo_pago
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new MetodoPago(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                    );
            }

            return null;
        }
        // UPDATE
        public bool Actualizar(MetodoPago metodoPago)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE metodo_pago
            SET
                Nombre = @Nombre
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Nombre", metodoPago.Nombre);
            command.Parameters.AddWithValue("@Id", metodoPago.Id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

        //DELETE
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM metodo_pago
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
