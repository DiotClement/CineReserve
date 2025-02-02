﻿namespace MovieRentMicroservice.Domain.Entities
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
		public TimeSpan Showtime { get; set; }
	}
}
