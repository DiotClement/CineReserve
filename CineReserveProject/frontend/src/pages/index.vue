<script lang="ts" setup>
import type { Movie } from '@/models/movie/MovieResponse';
import { MoviesService } from '@/services/api/MoviesService';
import { onMounted, ref } from 'vue';
import { useI18n } from 'vue-i18n';

const { t } = useI18n()

const movies = ref<Movie[]>([]);

const fetchAllMovies = async() => {
  const result = await MoviesService.getAllMovies()
  if (result.isSuccess) {
    movies.value = result.value
  } else {
    console.error("Error with the movies extraction :" + result.error.description)
  }
}

onMounted(fetchAllMovies)
</script>

<template>
  <v-container>
    <h2 class="title-medium">
      {{ t('homePage.newLabel') }}
    </h2>
    <v-row>
      <v-col
        v-for="movie in movies"
        :key="movie.id"
        cols="12"
        sm="6"
        md="4"
        lg="3"
      >
        <v-card>
          <v-img
            :alt="movie.title"
            class="v-card__image"
          />
          <v-card-text class="text-center">
            <h3 class="text-h6 font-weight-bold">
              {{ movie.title }}
            </h3>
          </v-card-text>
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
}
</style>
