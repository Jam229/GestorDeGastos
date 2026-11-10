using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class MetaAhorroRepository
    {
        private readonly string _connectionString;
        public MetaAhorroRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
        
        public int Crear(MetaAhorro metaAhorro)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO meta_ahorro (Nombre, MontoObjetivo, MontoActual, FechaLimite, CuentaId)
                VALUES (@Nombre, @MontoObjetivo, @MontoActual, @FechaLimite, @CuentaId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", metaAhorro.Nombre);
            command.Parameters.AddWithValue("@MontoObjetivo", metaAhorro.MontoObjetivo);
            command.Parameters.AddWithValue("@MontoActual", metaAhorro.MontoActual);
            command.Parameters.AddWithValue("@FechaLimite", metaAhorro.FechaLimite);
            command.Parameters.AddWithValue("@CuentaId", metaAhorro.CuentaId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
       

        public List<MetaAhorro> ObtenerTodos()
        {
            var metaAhorros = new List<MetaAhorro>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre, MontoObjetivo, MontoActual, FechaLimite, CuentaId
                FROM meta_ahorro;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var metaAhorro = new MetaAhorro(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetDecimal("MontoObjetivo"),
                        reader.GetDecimal("MontoActual"),
                        reader.GetDateTime("FechaLimite"),
                        reader.GetInt32("CuentaId")
                );

                metaAhorros.Add(metaAhorro);
            }
            return metaAhorros;
        }
        

     

        public MetaAhorro? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre, MontoObjetivo, MontoActual, FechaLimite, CuentaId
            FROM meta_ahorro
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new MetaAhorro(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetDecimal("MontoObjetivo"),
                        reader.GetDecimal("MontoActual"),
                        reader.GetDateTime("FechaLimite"),
                        reader.GetInt32("CuentaId")
                    );
            }

            return null;
        }
      
        public bool Actualizar(MetaAhorro metaAhorro)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE meta_ahorro
            SET
                Nombre = @Nombre,
                MontoObjetivo = @MontoObjetivo,
                MontoActual = @MontoActual,
                FechaLimite = @FechaLimite,
                CuentaId = @CuentaId
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", metaAhorro.Id);
            command.Parameters.AddWithValue("@Nombre", metaAhorro.Nombre);
            command.Parameters.AddWithValue("@MontoObjetivo", metaAhorro.MontoObjetivo);
            command.Parameters.AddWithValue("@MontoActual", metaAhorro.MontoActual);
            command.Parameters.AddWithValue("@FechaLimite", metaAhorro.FechaLimite);
            command.Parameters.AddWithValue("@CuentaId", metaAhorro.CuentaId);


            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

        
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM meta_ahorro
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
