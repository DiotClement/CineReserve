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
    <template #prepend>
      <v-img
        alt="Cine Reserve logo"
        :src="logo"
      />
    </template>

    <v-spacer />

    <v-btn
      to="/"
      color="white"
      variant="text"
      class="text-body-2 font-weight-bold d-flex flex-column"
      prepend-icon="mdi-magnify"
      stacked
    >
      <span>{{ t('navBar.home') }}</span>
    </v-btn>
  </v-app-bar>
</template>
