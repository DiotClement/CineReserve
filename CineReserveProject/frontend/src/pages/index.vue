<script lang="ts" setup>
import type { Movie } from '@/models/movie/MovieResponse';
import { MoviesService } from '@/services/api/MoviesService';
import { useSelectedMovieStore } from '@/stores/SelectedMovieStore';
import { computed, onMounted, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { useRouter } from 'vue-router';

const { t } = useI18n()

const selectedMovie = useSelectedMovieStore()
const router = useRouter()

const movies = ref<Movie[]>([]);

const fetchAllMovies = async() => {
  try {
    const result = await MoviesService.getAllMovies()
    if (result.isSuccess) {
      movies.value = result.value
    } else {
      console.error(result.error.description)
    }
  } catch (error) {
    console.error("Error with the movies extraction :" + error)
  }
}

const uppercaseMovies = computed(() => {
  return movies.value.map(movie => ({
    ...movie,
    title: movie.title.toUpperCase()
  }));
});

onMounted(() => {
  fetchAllMovies()
})

const handleClick = (movie: Movie) => {
  selectedMovie.setSelectedMovie(movie)
  router.push('/screeningsMovie')
}
</script>

<template>
  <v-container>
    <h2 class="title-medium">
      {{ t('homePage.newLabel') }}
    </h2>
    <v-row>
      <v-col
        v-for="movie in uppercaseMovies"
        :key="movie.id"
        cols="12"
        sm="6"
        md="4"
        lg="3"
      >
        <v-card>
          <v-img
            :alt="movie.title"
          />
          <v-card-text class="text-center">
            <h3 class="text-h6 font-weight-bold uppercase-title">
              {{ movie.title }}
            </h3>
          </v-card-text>
          <template #actions>
            <v-btn
              color="red-lighten-2"
              :text="t('homePage.screeningsLabel')"
              variant="outlined"
              rounded="0"
              size="x-large"
              class
              block
              @click="handleClick(movie)"
            />
          </template>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped>
.title-medium {
  font-size: 30px;
  line-height: 34px;
  font-weight: 500;
  margin-bottom: 5px;
  font-weight: bold;
}
</style>
