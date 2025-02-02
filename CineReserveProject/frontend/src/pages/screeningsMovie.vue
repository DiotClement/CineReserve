<script lang="ts" setup>
import type { Schedule } from '@/models/schedule/Schedule';
import { SchedulesService } from '@/services/api/SchedulesService';
import { useSelectedMovieStore } from '@/stores/SelectedMovieStore';
import { computed, onMounted, ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { fr } from 'date-fns/locale'
import { format } from 'date-fns'
import router from '@/router';
import { useToast } from 'vue-toast-notification';
import { ReservationsService } from '@/services/api/ReservationsService';
import type { ReservationRequest } from '@/models/reservation/Reservation';

const { t } = useI18n()

const selectedMovie = useSelectedMovieStore()

const schedules = ref<Schedule[]>([]);
const reservation = ref<ReservationRequest | null>(null);
const selectedScheduleId = ref<number | null>(null);
const seatCount = ref(1);

const fetchSchedulesByAMovie = async() => {
  try {
    if (!selectedMovie.movie) {
      console.error("No movie selected");
      return;
    }

    const result = await SchedulesService.getSchedulesByMovie(selectedMovie.movie.id)
    if (result.isSuccess) {
      schedules.value = result.value
    } else {
      console.error(result.error.description)
    }
  } catch (error) {
    console.error("Error with the schedules extraction :" + error)
  }
}

const durationInHours = computed(() => {
  if (selectedMovie.movie) {
    const hours = Math.floor(selectedMovie.movie.durationMinutes / 60)
    const minutes = selectedMovie.movie.durationMinutes % 60
    return `${hours}h ${minutes}m`
  }
  return ''
})

const formattedReleaseDate = computed(() => {
  if (selectedMovie.movie) {
    return format(new Date(selectedMovie.movie.releaseDate), 'PP', { locale: fr })
  }
  return ''
})

const formatTime = (time: string) => {
  return time.substring(0, 5)
}

const insertAMovieRent = async() => {
  try {
    const toast = useToast()
    if (!selectedMovie.movie) {
      console.error("No movie selected");
      return;
    }

    reservation.value = {
      seatCount: seatCount.value,
      showtimeId: selectedScheduleId.value!,
    }
    const result = await ReservationsService.insertMovieRent(reservation.value)
    if (result.isSuccess) {
      await toast.success(t("screeningPage.movieRentSuccess"))
      router.replace('/')
    } else {
      console.error(result.error.description)
    }
  } catch (error) {
    console.error("Error during inserting a movie rent in the database :" + error)
  }
}

onMounted(() => {
  if (!selectedMovie.movie){
    router.push('/')
  }
  fetchSchedulesByAMovie()
})
</script>

<template>
  <v-container v-if="selectedMovie.movie">
    <v-row>
      <h1 class="title-medium">
        {{ selectedMovie.movie.title }}
      </h1>
    </v-row>

    <v-row>
      <div>
        <span class="label-medium-star">
          {{ t("screeningPage.rateLabel") }}
        </span>
        <div>
          <span class="label-medium-star">
            ({{ selectedMovie.movie.star }})
          </span>
          <v-rating
            half-increments
            hover
            readonly
            :length="5"
            :size="32"
            :model-value="selectedMovie.movie.star"
            active-color="#9E00FF"
          />
        </div>
      </div>
    </v-row>

    <v-row>
      <h3>{{ t("screeningPage.durationLabel") }}</h3>
      <h3 class="h3-no-bold ml-2">
        {{ durationInHours }}
      </h3>
    </v-row>

    <v-row>
      <h3>{{ t("screeningPage.releaseDateLabel") }}</h3>
      <h3 class="h3-no-bold ml-2">
        {{ formattedReleaseDate }}
      </h3>
    </v-row>
    <br><br>

    <v-row>
      <h3 class="h3-no-bold">
        {{ selectedMovie.movie.description }}
      </h3>
    </v-row>
    <br><br>

    <v-row>
      <h1 class="title-medium">
        {{ t("screeningPage.screeningLabel") }}
      </h1>
    </v-row>

    <v-row>
      <v-col cols="auto">
        <v-btn
          v-for="schedule in schedules"
          :key="schedule.id"
          variant="outlined"
          prepend-icon="mdi-clock-time-four-outline"
          :color="selectedScheduleId === schedule.id ? 'primary' : 'grey-darken-1'"
          class="time-btn"
          stacked
          @click="selectedScheduleId = schedule.id"
        >
          {{ formatTime(schedule.showtime) }}
        </v-btn>
      </v-col>

      <div
        v-if="selectedScheduleId"
        class="ml-6"
      >
        <v-col cols="auto">
          <v-number-input
            v-model="seatCount"
            variant="outlined"
            control-variant="split"
            :max="4"
            :min="1"
          />
        </v-col>

        <v-col cols="auto">
          <v-btn
            color="primary"
            @click="insertAMovieRent"
          >
            {{ t("screeningPage.validateBtn") }}
          </v-btn>
        </v-col>
      </div>
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
  color: black;
}

.label-medium-star {
  font-size: 18px;
  line-height: 34px;
  font-weight: 500;
  margin-bottom: 5px;
  font-weight: bold;
  color: #9E00FF;
}

.h3-no-bold {
  font-weight: normal;
}

.v-chip {
  transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
  cursor: pointer;
  justify-content: center;
}

.v-chip--selected {
  border-color: rgb(var(--v-theme-primary));
  background-color: rgba(var(--v-theme-primary), 0.1);
}
</style>
