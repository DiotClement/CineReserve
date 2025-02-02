namespace MovieRentMicroservice.Domain.Entities
{
	/// <summary>
	/// The class representing the movie table.
	/// </summary>
	public class Movie
	{
		/// <summary>
		/// Gets or sets the identifier of the movie.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the title of the movie.
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the description of the movie.
		/// </summary>
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the duration in minutes of the movie.
		/// </summary>
		public int DurationMinutes { get; set; }

		/// <summary>
		/// Gets or sets the star of the movie.
		/// </summary>
		public int Star { get; set; }

		/// <summary>
		/// Gets or sets the release date of the movie.
		/// </summary>
		public DateTime ReleaseDate { get; set; }
	}
}
