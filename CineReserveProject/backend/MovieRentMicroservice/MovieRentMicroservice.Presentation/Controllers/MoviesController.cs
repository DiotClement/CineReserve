namespace MovieRentMicroservice.Presentation.Controllers
{
	using MovieRentMicroservice.Application.Movie.Queries;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// The movies controller.
	/// </summary>
	public sealed class MoviesController : BaseApiController
	{
		public MoviesController(IMediator mediator) : base(mediator) { }

		[HttpGet]
		public async Task<IActionResult> GetAllMovies(CancellationToken cancellationToken)
		{
			return await HandleRequestAsync(new GetAllMoviesQuery(), cancellationToken);
		}
	}
}
