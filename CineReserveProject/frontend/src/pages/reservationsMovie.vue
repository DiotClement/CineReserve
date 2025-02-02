<script lang="ts" setup>
import type { Reservation } from '@/models/reservation/Reservation';
import { ReservationsService } from '@/services/api/ReservationsService';
import { onMounted, ref } from 'vue';
import { useI18n } from 'vue-i18n';

const { t } = useI18n()

const reservations = ref<Reservation[]>([]);

const search = ref<string>('');
const loading = ref<boolean>(false);

const headers = [
  { title: t('reservationPage.movieTitleHeader'), value: 'title' },
  { title: t('reservationPage.screeningShowtimeHeader'), value: 'showtime' },
  { title: t('reservationPage.seatCount'), value: 'seatCount' },
]

const fetchReservations = async() => {
  loading.value = true
  try {
    const result = await ReservationsService.getAllReservations()
    if (result.isSuccess) {
      reservations.value = result.value
    } else {
      console.error(result.error.description)
    }
  } catch (error) {
    console.error("Error with the reservations extraction :" + error)
  } finally {
    loading.value = false
  }
}

onMounted(() => {
  fetchReservations()
})
</script>

<template>
  <v-card flat>
    <v-card-title class="d-flex align-center">
      <v-icon
        size="35"
        icon="mdi-ticket-outline"
      />&nbsp;
      <h2>{{ t('reservationPage.title') }}</h2>

      <v-spacer />

      <v-text-field
        v-model="search"
        :label="$t('reservationPage.search')"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        dense
        hide-details
      />

      <v-btn
        :disabled="loading"
        icon
        class="ml-2"
        @click="fetchReservations"
      >
        <v-icon>mdi-refresh</v-icon>
      </v-btn>
    </v-card-title>

    <v-divider />

    <v-data-table
      :headers="headers"
      :items="reservations"
      :search="search"
      :loading="loading"
      :hover="true"
      item-key="id"
    />
  </v-card>
</template>
