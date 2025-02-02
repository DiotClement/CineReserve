namespace MovieRentMicroservice.Presentation.Controllers
{
	using MovieRentMicroservice.Domain.Abstractions;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// This class represents the base api controller for the other controllers.
	/// </summary>
	[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
	[ApiController]
	public abstract class BaseApiController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BaseApiController(IMediator mediator)
		{
			_mediator = mediator;
		}

		protected virtual async Task<IActionResult> HandleRequestAsync<TResponse>(
			IRequest<Result<TResponse>> request,
			CancellationToken cancellationToken = default)
		{
			Result<TResponse> result = await _mediator.Send(request, cancellationToken);

			return result.Match(
				onSuccess: data => Ok(Result.Success(data)),
				onFailure: Problem);
		}

		protected IActionResult Problem(Error error)
		{
			int statusCode = error.ErrorType switch
			{
				ErrorType.NotFound => StatusCodes.Status404NotFound,
				ErrorType.Conflict => StatusCodes.Status409Conflict,
				ErrorType.Problem => StatusCodes.Status400BadRequest,
				ErrorType.Failure => StatusCodes.Status500InternalServerError,
				_ => StatusCodes.Status500InternalServerError
			};

			return Problem(
				statusCode: statusCode,
				title: error.Description,
				detail: error.Code);
		}
	}
}
