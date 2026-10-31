using System.Security.Cryptography;

namespace GestorDeGastos.Services
{
    public class HashService
    {
        private const int TamanoSal = 16;
        private const int TamanoHash = 32;
        private const int Iteraciones = 600000;

        public string Hashear(string contrasena)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(TamanoSal);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                contrasena,
                sal,
                Iteraciones,
                HashAlgorithmName.SHA256,
                TamanoHash);

            return $"{Iteraciones}.{Convert.ToBase64String(sal)}.{Convert.ToBase64String(hash)}";
        }

        public bool Verificar(string contrasena, string hashGuardado)
        {
            string[] partes = hashGuardado.Split('.');

            if (partes.Length != 3 || !int.TryParse(partes[0], out int iteraciones))
            {
                return false;
            }

            byte[] sal = Convert.FromBase64String(partes[1]);
            byte[] hashEsperado = Convert.FromBase64String(partes[2]);

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(
                contrasena,
                sal,
                iteraciones,
                HashAlgorithmName.SHA256,
                hashEsperado.Length);

            return CryptographicOperations.FixedTimeEquals(hashCalculado, hashEsperado);
        }
    }
}