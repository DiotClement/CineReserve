namespace MovieRentMicroservice.Application.Reservation.QueryHandlers
{
	using Dapper;
	using MediatR;
	using MovieRentMicroservice.Application.Abstractions;
	using MovieRentMicroservice.Application.Reservation.Queries;
	using MovieRentMicroservice.Domain.Abstractions;
	using MovieRentMicroservice.Domain.Entities;
	using Npgsql;

	/// <summary>
	/// This class represents the query handler used for getting all the reservations from the database.
	/// </summary>
	internal sealed class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, Result<IEnumerable<Reservation>>>
	{
		private readonly IDbConnectionFactory _connectionFactory;

		public GetAllReservationsQueryHandler(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<Result<IEnumerable<Reservation>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
		{
			await using NpgsqlConnection dbConnection = _connectionFactory.CreateConnection();

			IEnumerable<Reservation>? reservations = await dbConnection.QueryAsync<Reservation>(@"SELECT SUM(r_seat_count) AS SeatCount, m_title AS Title, s_showtime AS Showtime
																							      FROM public.m_reservation
																								  INNER JOIN public.m_schedule ON r_fk_showtime_id = m_schedule.s_id
																								  INNER JOIN public.m_movie ON s_fk_movie_id = m_movie.m_id
																								  GROUP BY (m_title, s_showtime)
																								  ORDER BY m_title,s_showtime ASC;");

			if (!reservations.Any())
			{
				return Result.Failure<IEnumerable<Reservation>>(ReservationsErrors.NoReservationFound);
			}

			return Result.Success(reservations);
		}
	}
}
