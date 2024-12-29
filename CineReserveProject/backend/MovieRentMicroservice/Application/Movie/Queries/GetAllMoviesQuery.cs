namespace Application.Movie.Queries
{
	using MediatR;
	using Domain.Entities;
	using Domain.Abstractions;

	/// <summary>
	/// This class represents the query used by MediatR in the call endpoint.
	/// </summary>
	public record GetAllMoviesQuery : IRequest<Result<IEnumerable<Movie>>>
	{
	}
}
