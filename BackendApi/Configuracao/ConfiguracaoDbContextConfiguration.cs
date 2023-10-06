using BackendApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Configuracao
{
    public static class ConfiguracaoDbContextConfiguration
    {
        public static void ConfigurarDbContext(this IServiceCollection services, string filePath)
        {
            string connectionString = ReadConnectionStringFromFile(filePath);
            services.AddDbContext<MeuContext>(options => options.UseSqlServer(connectionString));
        }

        private static string ReadConnectionStringFromFile(string filePath)
        {
            try
            {
                // Lê o conteúdo do arquivo e substitui "\\" por "\"
                string connectionString = File.ReadAllText(filePath).Replace("\\\\", "\\");
                return connectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler a string de conexão do arquivo.", ex);
            }
        }
    }
}
