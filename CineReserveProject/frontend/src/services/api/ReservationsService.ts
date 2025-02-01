import { AxiosConfigurator } from "./AxiosConfigurator"
import type { Reservation } from "@/models/reservation/ReservationRequest"
import type { RequestResponse } from "@/models/response/RequestResponse"

/**
 * Defines the axios service for dealing with the api to perform reservations queries.
 */
export class ReservationsService {
  /**
   * Configured the axios instance with the api url and endpoint
   * @returns {AxiosConfigurator} A axios instance.
   */
  public static getAxios(){
    return AxiosConfigurator.getInstance(import.meta.env.VITE_API_URL, "Reservations")
  }

  /**
   * Insert the reservation of a movie in the database.
   * @returns {ScheduleListResponse} A schedules movie list.
   */
  public static async insertMovieRent(reservationRequest: Reservation) {
    const axios = this.getAxios()
    const response = await axios.post<RequestResponse<boolean>>("movierent", reservationRequest)
    return response.data
  }
}
