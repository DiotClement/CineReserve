namespace MovieRentMicroservice.Application.Reservation.Queries
{
	using MediatR;
	using MovieRentMicroservice.Domain.Abstractions;
	using MovieRentMicroservice.Domain.Entities;

	/// <summary>
	/// This class represents the query used by MediatR in the call endpoint.
	/// </summary>
	public record GetAllReservationsQuery : IRequest<Result<IEnumerable<Reservation>>>
	{
	}
}
