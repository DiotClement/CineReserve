<script lang="ts" setup>
import { useSelectedMovieStore } from '@/stores/SelectedMovieStore';
import { useI18n } from 'vue-i18n';

const { t } = useI18n()

const selectedMovie = useSelectedMovieStore()

</script>

<template>
  <v-container>
    <h2 class="title-medium">
      {{ t('homePage.newLabel') }}
    </h2>
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
