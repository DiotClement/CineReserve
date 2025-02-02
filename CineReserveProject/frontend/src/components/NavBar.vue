<script lang="ts" setup>
import { useI18n } from 'vue-i18n'
import logo from "@/assets/logo.png"

const { t } = useI18n()
</script>

<template>
  <v-app-bar
    color="primary"
    height="100"
  >
    <v-spacer />
    <v-img
      alt="Cine Reserve logo"
      :src="logo"
      class="mx-8"
    />

    <v-spacer />

    <div class="d-flex">
      <v-btn
        to="/"
        color="white"
        variant="text"
        class="text-body-2 flex-column mx-2"
        prepend-icon="mdi-movie-open-outline"
        stacked
      >
        <span>{{ t('navBar.home') }}</span>
      </v-btn>
      <v-btn
        to="/reservationsMovie"
        color="white"
        variant="text"
        class="text-body-2 flex-column"
        prepend-icon="mdi-ticket-outline"
        stacked
      >
        <span>{{ t('navBar.reservation') }}</span>
      </v-btn>
    </div>

    <v-spacer />
  </v-app-bar>
</template>