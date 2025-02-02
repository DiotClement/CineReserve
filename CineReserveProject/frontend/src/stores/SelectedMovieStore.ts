import type { Movie } from "@/models/movie/Movie";
import { defineStore } from "pinia";

export const useSelectedMovieStore = defineStore("selectedMovie", {
  state: () => ({
    movie: null as Movie | null,
  }),
  actions: {
    setSelectedMovie(movie: Movie) {
      this.movie = movie;
    },
  },
})
