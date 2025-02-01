import type { MovieListResponse } from "@/models/response/movie/MovieResponse";
import { AxiosConfigurator } from "./AxiosConfigurator";

/**
 * Defines the axios service for dealing with the api to perform movies queries.
 */
export class MoviesService {
  /**
   * Configured the axios instance with the api url and endpoint
   * @returns {AxiosConfigurator} A axios instance.
   */
  public static getAxios(){
    return AxiosConfigurator.getInstance(import.meta.env.VITE_API_URL, "Movies")
  }

  /**
   * Retrieves all movies from the database
   * @returns {MovieListResponse} A movies list.
   */
  public static async getAllMovies() {
    const axios = this.getAxios()
    const response = await axios.get<MovieListResponse>("")
    return response.data
  }
}
