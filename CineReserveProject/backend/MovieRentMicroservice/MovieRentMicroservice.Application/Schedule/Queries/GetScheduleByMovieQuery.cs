namespace MovieRentMicroservice.Application.Schedule.Queries
{
	using MovieRentMicroservice.Domain.Entities;
	using MovieRentMicroservice.Domain.Abstractions;
	using MediatR;

	/// <summary>
	/// This class represents the query used by MediatR in the call endpoint.
	/// </summary>
	public record GetScheduleByMovieQuery : IRequest<Result<IEnumerable<Schedule>>>
	{
		public int MovieId { get; set; }
	}
}
