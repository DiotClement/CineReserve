namespace MovieRentMicroservice.Domain.Entities
{
	/// <summary>
	/// The class representing the reservation table.
	/// </summary>
	public class Reservation
	{
		/// <summary>
		/// Gets or sets the identifier of the reservation.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the seat count.
		/// </summary>
		public int SeatCount { get; set; }
	}
}
