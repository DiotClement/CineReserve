namespace Application.Schedule.QueryHandlers
{
	using Application.Abstractions;
	using Application.Schedule.Queries;
	using Dapper;
	using Domain.Abstractions;
	using Domain.Entities;
	using MediatR;
	using Npgsql;

	/// <summary>
	/// This class represents the query handler used for getting all the schedules for a movie from the database.
	/// </summary>
	internal sealed class GetScheduleByMovieQueryHandler : IRequestHandler<GetScheduleByMovieQuery, Result<IEnumerable<Schedule>>>
	{
		private readonly IDbConnectionFactory _connectionFactory;

		public GetScheduleByMovieQueryHandler(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<Result<IEnumerable<Schedule>>> Handle(GetScheduleByMovieQuery request, CancellationToken cancellationToken)
		{
			await using NpgsqlConnection dbConnection = _connectionFactory.CreateConnection();

			IEnumerable<Schedule>? schedules = await dbConnection.QueryAsync<Schedule>(@"SELECT s_id as Id, s_showtime as Showtime 
																						 FROM m_schedule
																						 LEFT JOIN m_movie ON s_fk_movie_id = m_movie.m_id
																						 WHERE s_fk_movie_id = @MovieId", new { MovieId = request.MovieId });
																					
			if (!schedules.Any())
			{
				return Result.Failure<IEnumerable<Schedule>>(ScheduleErrors.NoScheduleFound);
			}

			return Result.Success(schedules);
		}

	}
}