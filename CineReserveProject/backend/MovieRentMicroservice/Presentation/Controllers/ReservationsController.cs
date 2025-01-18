namespace Presentation.Controllers
{
	using Application.Reservation.Commands;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;

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
	}
}
