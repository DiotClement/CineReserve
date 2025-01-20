namespace MovieRentMicroservice.Infrastructure.Persistance
{
    using MovieRentMicroservice.Application.Abstractions;
    using Microsoft.Extensions.Configuration;
    using Npgsql;

    /// <summary>
    /// This class represents the creation of the connection to the postgre database.
    /// </summary>
    internal sealed class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(
                _configuration.GetConnectionString("PostgreSqlConnection"));
        }
    }
}
