namespace Domain.Entities
{
	/// <summary>
	/// The class representing the schedule table.
	/// </summary>
	public class Schedule
	{
		/// <summary>
		/// Gets or sets the identifier of the schedule.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the showtime.
		/// </summary>
		public int Showtime { get; set; }

		/// <summary>
		/// Gets or sets the associated movie.
		/// </summary>
		public Movie Movie { get; set; } = new Movie();
	}
}
