namespace Application.Reservation.Commands
{
	using Domain.Abstractions;
	using MediatR;

	/// <summary>
	/// This class represents the command used by MediatR in the call endpoint.
	/// </summary>
	public record class InsertMovieRentCommand : IRequest<Result<bool>>
	{
		public int SeatCount { get; set; }

		public int ShowtimeId { get; set; }
	}
}
