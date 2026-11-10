using GestorDeGastos.Models;
using MySqlConnector;

namespace GestorDeGastos.Repositories
{
    public class CuentaRepository
    {
        private readonly string _connectionString;
        public CuentaRepository()
        {
            _connectionString = "Server=localhost;Port=3306;Database=gestor_gastos;User=root;Password=;";
        }
     
        public int Crear(Cuenta cuenta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO cuenta (Nombre,NumeroCuenta, Saldo, UsuarioId)
                VALUES (@Nombre, @NumeroCuenta, @Saldo, @UsuarioId);

                SELECT LAST_INSERT_ID();
            ";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nombre", cuenta.Nombre);
            command.Parameters.AddWithValue("@NumeroCuenta", cuenta.NumeroCuenta);
            command.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
            command.Parameters.AddWithValue("@UsuarioId", cuenta.UsuarioId);

            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
      

        public List<Cuenta> ObtenerTodos()
        {
            var cuentas = new List<Cuenta>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT Id, Nombre, NumeroCuenta, Saldo, UsuarioId
                FROM cuenta;
            ";

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var cuenta = new Cuenta(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetString("NumeroCuenta"),
                        reader.GetDecimal("Saldo"),
                        reader.GetInt32("UsuarioId")
                );

                cuentas.Add(cuenta);
            }
            return cuentas;
        }

      

        public Cuenta? ObtenerPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            SELECT Id, Nombre, NumeroCuenta, Saldo, UsuarioId
            FROM cuenta
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Cuenta(
                        reader.GetInt32("Id"),
                        reader.GetString("Nombre"),
                        reader.GetString("NumeroCuenta"),
                        reader.GetDecimal("Saldo"),
                        reader.GetInt32("UsuarioId")
                    );
            }

            return null;
        }
 
        public bool Actualizar(Cuenta cuenta)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            UPDATE cuenta
            SET
                Nombre = @Nombre, 
                NumeroCuenta = @NumeroCuenta,
                Saldo = @Saldo, 
                UsuarioId = @UsuarioId
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Nombre", cuenta.Nombre);
            command.Parameters.AddWithValue("@Id", cuenta.Id);
            command.Parameters.AddWithValue("@NumeroCuenta", cuenta.NumeroCuenta);
            command.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
            command.Parameters.AddWithValue("@UsuarioId", cuenta.UsuarioId);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }


        public bool Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            DELETE FROM cuenta
            WHERE Id = @Id;
        ";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas > 0;
        }



        public bool Transferir(int cuentaOrigenId, int cuentaDestinoId, decimal monto)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sqlDebito = @"
            UPDATE cuenta
            SET Saldo = Saldo - @Monto
            WHERE Id = @CuentaId AND Saldo >= @Monto;
        ";
            using var comandoDebito = new MySqlCommand(sqlDebito, connection);
            comandoDebito.Parameters.AddWithValue("@CuentaId", cuentaOrigenId);
            comandoDebito.Parameters.AddWithValue("@Monto", monto);

            if (comandoDebito.ExecuteNonQuery() == 0)
            {
                return false;
            }

            string sqlCredito = @"
            UPDATE cuenta
            SET Saldo = Saldo + @Monto
            WHERE Id = @CuentaId;
        ";

            using var comandoCredito = new MySqlCommand(sqlCredito, connection);
            comandoCredito.Parameters.AddWithValue("@CuentaId", cuentaDestinoId);
            comandoCredito.Parameters.AddWithValue("@Monto", monto);

            if (comandoCredito.ExecuteNonQuery() == 0)
            {

                string sqlReverso = @"
                UPDATE cuenta
                SET Saldo = Saldo + @Monto
                WHERE Id = @CuentaId;
            ";
                using var comandoReverso = new MySqlCommand(sqlReverso, connection);
                comandoReverso.Parameters.AddWithValue("@CuentaId", cuentaOrigenId);
                comandoReverso.Parameters.AddWithValue("@Monto", monto);

                comandoReverso.ExecuteNonQuery();
                return false;
            }

            return true;

        }
    }
}
