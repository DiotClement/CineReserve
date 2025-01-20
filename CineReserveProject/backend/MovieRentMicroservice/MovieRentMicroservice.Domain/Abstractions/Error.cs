namespace MovieRentMicroservice.Domain.Abstractions
{
	/// <summary>
	/// This class represent application errors.
	/// </summary>
	public enum ErrorType
	{
		NotFound,
		Failure,
		Problem,
		Conflict
	}

	public record Error
	{
		public string Code { get; }

		public string Description { get; }

		public ErrorType ErrorType { get; }

		public Error(string code, string description, ErrorType errorType)
		{
			Code = code;
			Description = description;
			ErrorType = errorType;
		}

		public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

		public static Error NotFound(string code, string description) =>
			new(code, description, ErrorType.NotFound);

		public static Error Failure(string code, string description) =>
			new(code, description, ErrorType.Failure);

		public static Error Problem(string code, string description) =>
			new(code, description, ErrorType.Problem);

		public static Error Conflict(string code, string description) =>
			new(code, description, ErrorType.Conflict);
	}

	
	public static class MoviesErrors
	{
		public static readonly Error NoMovieFound = Error.NotFound("Movies.NotFound", "No movies found in the database.");
	}

	public static class ScheduleErrors
	{
		public static readonly Error NoScheduleFound = Error.NotFound("Schedules.NotFound", "No schedule found for this movie in the database.");
	}

	public static class ReservationsErrors
	{
		public static readonly Error InsertReservationFailure = Error.Failure("Reservations.Failure", "Error executing the sql query to insert a reservation in the database.");
	}
}
