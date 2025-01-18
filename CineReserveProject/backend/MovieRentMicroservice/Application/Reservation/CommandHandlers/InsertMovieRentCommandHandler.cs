namespace Application.Reservation.CommandHandlers
{
	using Application.Abstractions;
	using Application.Reservation.Commands;
	using Dapper;
	using Domain.Abstractions;
	using MediatR;
	using Npgsql;

	/// <summary>
	/// This class represents the command handler used for inserting a movie rent in the database.
	/// </summary>
	internal sealed class InsertMovieRentCommandHandler : IRequestHandler<InsertMovieRentCommand, Result<bool>>
	{
		private readonly IDbConnectionFactory _connectionFactory;

		public InsertMovieRentCommandHandler(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<Result<bool>> Handle(InsertMovieRentCommand request, CancellationToken cancellationToken)
		{
			await using NpgsqlConnection dbConnection = _connectionFactory.CreateConnection();

			int rowsAffected = await dbConnection.ExecuteAsync(@"INSERT INTO m_reservation(r_seat_count, r_fk_showtime_id)
																 VALUES (@SeatCount, @ShowtimeId)", new {SeatCount = request.SeatCount, ShowtimeId = request.ShowtimeId});

			if (rowsAffected == 0)
			{
				return Result.Failure<bool>(ReservationsErrors.InsertReservationFailure);
			}

			return Result.Success(true);
		}
	}
}
