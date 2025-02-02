import type { ReservationRequest } from "@/models/reservation/Reservation"
import { AxiosConfigurator } from "./AxiosConfigurator"
import type { RequestResponse } from "@/models/response/RequestResponse"
import type { ReservationListResponse } from "@/models/response/reservation/ReservationResponse"

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
     * Retrieves all reservations from the database
     * @returns {ReservationListResponse} A reservations list.
     */
    public static async getAllReservations() {
      const axios = this.getAxios()
      const response = await axios.get<ReservationListResponse>("")
      return response.data
    }

  /**
   * Insert the reservation of a movie in the database.
   * @returns {boolean} If success i return true.
   */
  public static async insertMovieRent(reservationRequest: ReservationRequest) {
    const axios = this.getAxios()
    const response = await axios.post<RequestResponse<boolean>>("movierent", reservationRequest)
    return response.data
  }
}
