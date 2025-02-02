import type { Movie } from "@/models/movie/Movie"
import type { RequestResponse } from "../RequestResponse"

export type MovieResponse = RequestResponse<Movie>
export type MovieListResponse = RequestResponse<Movie[]>
