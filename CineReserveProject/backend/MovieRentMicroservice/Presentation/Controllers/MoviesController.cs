
using Application.Movie.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	/// <summary>
	/// The movies controller.
	/// </summary>
	public sealed class MoviesController : BaseApiController
	{
		public MoviesController(IMediator mediator) : base(mediator) { }

		public async Task<IActionResult> GetAllMovies(CancellationToken cancellationToken)
		{
			return await HandleRequestAsync(new GetAllMoviesQuery(), cancellationToken);
		}
	}
}
