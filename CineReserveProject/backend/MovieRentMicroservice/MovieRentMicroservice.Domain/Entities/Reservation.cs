namespace MovieRentMicroservice.Domain.Entities
{
	/// <summary>
	/// The class representing the reservation table.
	/// </summary>
	public class Reservation
	{
		/// <summary>
		/// Gets or sets the seat count.
		/// </summary>
		public int SeatCount { get; set; }

		/// <summary>
		/// Gets or sets the title of the movie.
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the showtime.
		/// </summary>
		public TimeSpan Showtime { get; set; }
	}
}
