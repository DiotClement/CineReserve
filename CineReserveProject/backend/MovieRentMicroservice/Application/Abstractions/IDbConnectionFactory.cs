namespace Application.Abstractions
{
	using Npgsql;

	/// <summary>
	/// This interface enables the Sql connection to be used in the application layer.
	/// </summary>
	public interface IDbConnectionFactory
	{
		NpgsqlConnection CreateConnection();
	}
}
