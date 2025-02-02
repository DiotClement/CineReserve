namespace MovieRentMicroservice.Presentation.Controllers
{
	using MovieRentMicroservice.Application.Reservation.Commands;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using MovieRentMicroservice.Application.Reservation.Queries;

	/// <summary>
	/// The reservations controller.
	/// </summary>
	public sealed class ReservationsController : BaseApiController
	{
		public ReservationsController(IMediator mediator) : base(mediator) { }

		[Route("movierent")]
		[HttpPost]
		public async Task<IActionResult> InsertMovieRent([FromBody] InsertMovieRentCommand request, CancellationToken cancellationToken)
		{
			return await HandleRequestAsync(request, cancellationToken);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllReservations(CancellationToken cancellationToken)
		{
			return await HandleRequestAsync(new GetAllReservationsQuery(), cancellationToken);
		}
	}
}
