using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
       
        public int Crear(Usuario usuario)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO usuario (Nombre, Apellido, Documento, Correo, ContrasenaHash)
                VALUES (@Nombre, @Apellido, @Documento, @Correo, @ContrasenaHash);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@Documento", usuario.Documento);
            command.Parameters.AddWithValue("@Correo", usuario.Correo);
            command.Parameters.AddWithValue("@ContrasenaHash", usuario.ContrasenaHash);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        

        public List<Usuario> ObtenerTodos()
        {
            var usuarios = new List<Usuario>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre, Apellido, Documento, Correo, ContrasenaHash
                FROM usuario;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var usuario = new Usuario(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetString("Apellido"),
                        reader.GetString("Documento"),
                        reader.GetString("Correo"),
                        reader.GetString("ContrasenaHash")
                );

                usuarios.Add(usuario);
            }
            return usuarios;
        }
        

        public Usuario? ObtenerPorDocumento(string documento)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre, Apellido, Documento, Correo, ContrasenaHash
            FROM usuario
            WHERE Documento = @Documento;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Documento", documento);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetString("Apellido"),
                        reader.GetString("Documento"),
                        reader.GetString("Correo"),
                        reader.GetString("ContrasenaHash")
                    );
            }

            return null;

        }

        

        public Usuario? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre, Apellido, Documento, Correo, ContrasenaHash
            FROM usuario
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetString("Apellido"),
                        reader.GetString("Documento"),
                        reader.GetString("Correo"),
                        reader.GetString("ContrasenaHash")
                    );
            }

            return null;
        }
        
        public bool Actualizar(Usuario usuario)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE usuario
            SET
                Nombre = @Nombre,
                Apellido = @Apellido,
                Documento = @Documento,
                Correo = @Correo,
                ContrasenaHash = @ContrasenaHash
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@Documento", usuario.Documento);
            command.Parameters.AddWithValue("@Correo", usuario.Correo);
            command.Parameters.AddWithValue("@ContrasenaHash", usuario.ContrasenaHash);


            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

       
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM usuario
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
