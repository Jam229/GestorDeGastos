using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class PresupuestoRepository
    {
        private readonly string _connectionString;
        public PresupuestoRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
        
        public int Crear(Presupuesto presupuesto)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO presupuesto (ValorLimite, FechaInicio, FechaFin, CategoriaId, UsuarioId)
                VALUES (@ValorLimite, @FechaInicio, @FechaFin, @CategoriaId, @UsuarioId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@ValorLimite", presupuesto.ValorLimite);
            command.Parameters.AddWithValue("@FechaInicio", presupuesto.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", presupuesto.FechaFin);
            command.Parameters.AddWithValue("@CategoriaId", presupuesto.CategoriaId);
            command.Parameters.AddWithValue("@UsuarioId", presupuesto.UsuarioId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        

        public List<Presupuesto> ObtenerTodos()
        {
            var presupuestos = new List<Presupuesto>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, ValorLimite, FechaInicio, FechaFin, CategoriaId, UsuarioId
                FROM presupuesto;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var presupuesto = new Presupuesto(
                        reader.GetInt32("Id"),
                        reader.GetDecimal("ValorLimite"),
                        reader.GetDateTime("FechaInicio"),
                        reader.GetDateTime("FechaFin"),
                        reader.GetInt32("CategoriaId"),
                        reader.GetInt32("UsuarioId")
                );

                presupuestos.Add(presupuesto);
            }
            return presupuestos;
        }

        

        public Presupuesto? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, ValorLimite, FechaInicio, FechaFin, CategoriaId, UsuarioId
            FROM presupuesto
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Presupuesto(
                        reader.GetInt32("Id"),
                        reader.GetDecimal("ValorLimite"),
                        reader.GetDateTime("FechaInicio"),
                        reader.GetDateTime("FechaFin"),
                        reader.GetInt32("CategoriaId"),
                        reader.GetInt32("UsuarioId")
                    );
            }

            return null;
        }
       
        public bool Actualizar(Presupuesto presupuesto)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE presupuesto
            SET
                ValorLimite = @ValorLimite,
                FechaInicio = @FechaInicio,
                FechaFin = @FechaFin,
                CategoriaId = @CategoriaId,
                UsuarioId = @UsuarioId
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", presupuesto.Id);
            command.Parameters.AddWithValue("@ValorLimite", presupuesto.ValorLimite);
            command.Parameters.AddWithValue("@FechaInicio", presupuesto.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", presupuesto.FechaFin);
            command.Parameters.AddWithValue("@CategoriaId", presupuesto.CategoriaId);
            command.Parameters.AddWithValue("@UsuarioId", presupuesto.UsuarioId);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }

        
        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM presupuesto
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }
    }
}
