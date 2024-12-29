namespace Application.Movie.QueryHandlers
{
	using Application.Movie.Queries;
	using MediatR;
	using Domain.Entities;
	using Application.Abstractions;
	using Npgsql;
	using Dapper;
	using Domain.Abstractions;
	
	/// <summary>
	/// This class represents the query handler used for getting all the movies from the database.
	/// </summary>
	internal sealed class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, Result<IEnumerable<Movie>>>
	{
		private readonly IDbConnectionFactory _connectionFactory;

		public GetAllMoviesQueryHandler(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<Result<IEnumerable<Movie>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
		{
			await using NpgsqlConnection dbConnection = _connectionFactory.CreateConnection();

			IEnumerable<Movie>? movies = await dbConnection.QueryAsync<Movie>(@"SELECT m_id as Id, m_title as Title, m_description as Description, m_duration_minutes as DurationMinutes, m_star as Star, m_release_date as ReleaseDate 
																			    FROM m_movie");

			if (!movies.Any()) 
			{
				return Result.Failure<IEnumerable<Movie>>(MoviesErrors.NoMovieFound);
			}

			return Result.Success(movies);
		}
	}
}
