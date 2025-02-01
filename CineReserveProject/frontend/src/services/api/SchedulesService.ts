import type { ScheduleListResponse } from "@/models/response/schedule/ScheduleResponse"
import { AxiosConfigurator } from "./AxiosConfigurator"

/**
 * Defines the axios service for dealing with the api to perform shedules queries.
 */
export class SchedulesService {
  /**
   * Configured the axios instance with the api url and endpoint
   * @returns {AxiosConfigurator} A axios instance.
   */
  public static getAxios(){
    return AxiosConfigurator.getInstance(import.meta.env.VITE_API_URL, "Schedules")
  }

  /**
   * Retrieve the schedules for a movie.
   * @returns {ScheduleListResponse} A schedules movie list.
   */
  public static async getSchedulesByMovie(movieId: number) {
    const axios = this.getAxios()
    const response = await axios.get<ScheduleListResponse>(`bymovie?movieId=${movieId}`)
    return response.data
  }
}
