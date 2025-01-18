namespace Presentation.Controllers
{
	using Application.Schedule.Queries;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// The schedules controller.
	/// </summary>
	public sealed class SchedulesController : BaseApiController
	{
		public SchedulesController(IMediator mediator) : base(mediator) { }

		[Route("bymovie")]
		[HttpGet]
		public async Task<IActionResult> GetScheduleByMovie([FromQuery] GetScheduleByMovieQuery request, CancellationToken cancellationToken)
		{
			return await HandleRequestAsync(request, cancellationToken);
		}
	}
}
