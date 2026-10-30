using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class EtiquetaRepository
    {
        private readonly string _connectionString;
        public EtiquetaRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
        //CREATE
        public int Crear(Etiqueta etiqueta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO etiqueta (Nombre)
                VALUES (@Nombre);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", etiqueta.Nombre);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        //READ - obtener todos

        public List<Etiqueta> ObtenerTodos()
        {
            var etiquetas = new List<Etiqueta>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre
                FROM etiqueta;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var etiqueta = new Etiqueta(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                );

                etiquetas.Add(etiqueta);
            }
            return etiquetas;
        }

        //READ - obtener por Id

        public Etiqueta? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre
            FROM etiqueta
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Etiqueta(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                    );
            }

            return null;
        }
        // UPDATE
        public bool Actualizar(Etiqueta etiqueta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE etiqueta
            SET
                Nombre = @Nombre
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Nombre", etiqueta.Nombre);
            command.Parameters.AddWithValue("@Id", etiqueta.Id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

        //DELETE
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM etiqueta
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
