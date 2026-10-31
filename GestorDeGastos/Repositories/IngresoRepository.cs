using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class IngresoRepository
    {
        private readonly string _connectionString;
        public IngresoRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
        //CREATE
        public int Crear(Ingreso ingreso)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO ingreso (Descripcion, Valor, Fecha, CuentaId)
                VALUES (@Descripcion, @Valor, @Fecha, @CuentaId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Descripcion", ingreso.Descripcion);
            command.Parameters.AddWithValue("@Valor", ingreso.Valor);
            command.Parameters.AddWithValue("@Fecha", ingreso.Fecha);
            command.Parameters.AddWithValue("@CuentaId", ingreso.CuentaId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        //READ - obtener todos

        public List<Ingreso> ObtenerTodos()
        {
            var ingresos = new List<Ingreso>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Descripcion, Valor, Fecha, CuentaId
                FROM ingreso;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var ingreso = new Ingreso(
                        reader.GetInt32("Id"),
                        reader.GetString("Descripcion"),
                        reader.GetDecimal("Valor"),
                        reader.GetDateTime("Fecha"),
                        reader.GetInt32("CuentaId")
                );

                ingresos.Add(ingreso);
            }
            return ingresos;
        }

        //READ - obtener por Id

        public Ingreso? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Descripcion, Valor, Fecha, CuentaId
            FROM ingreso
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Ingreso(
                        reader.GetInt32("Id"),
                        reader.GetString("Descripcion"),
                        reader.GetDecimal("Valor"),
                        reader.GetDateTime("Fecha"),
                        reader.GetInt32("CuentaId")
                    );
            }

            return null;
        }
        // UPDATE
        public bool Actualizar(Ingreso ingreso)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE ingreso
            SET
                Descripcion = @Descripcion,
                Valor = @Valor,
                Fecha = @Fecha,
                CuentaId = @CuentaId
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", ingreso.Id);
            command.Parameters.AddWithValue("@Descripcion", ingreso.Descripcion);
            command.Parameters.AddWithValue("@Valor", ingreso.Valor);
            command.Parameters.AddWithValue("@Fecha", ingreso.Fecha);
            command.Parameters.AddWithValue("@CuentaId", ingreso.CuentaId);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

        //DELETE
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM ingreso
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
