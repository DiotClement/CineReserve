export type Reservation = {
  seatCount: number;
  title: string;
  showtime: string;
}

export type ReservationRequest = {
  seatCount: number;
  showtimeId: number;
}
