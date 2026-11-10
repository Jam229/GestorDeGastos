using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class CategoriaRepository
    {
        private readonly string _connectionString;
        public CategoriaRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
    
        public int Crear(Categoria categoria)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO categoria (Nombre)
                VALUES (@Nombre);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", categoria.Nombre);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
     

        public List<Categoria> ObtenerTodos()
        {
            var categorias = new List<Categoria>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre
                FROM categoria;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var categoria = new Categoria(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                );

                categorias.Add(categoria);
            }
            return categorias;
        }

      

        public Categoria? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre
            FROM categoria
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Categoria(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre")
                    );
            }

            return null;
        }
    
        public bool Actualizar(Categoria categoria)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE categoria
            SET
                Nombre = @Nombre
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            command.Parameters.AddWithValue("@Id", categoria.Id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

     
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM categoria
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }

}
