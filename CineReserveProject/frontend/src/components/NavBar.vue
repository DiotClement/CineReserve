<script lang="ts" setup>
import { useI18n } from 'vue-i18n'
import logo from "@/assets/logo.png"

const { t } = useI18n()
</script>

<template>
  <v-app-bar
    color="#00134D"
    height="100"
  >
    <template #prepend>
      <v-img
        alt="Cine Reserve logo"
        :src="logo"
      />

      <v-spacer />

      <v-btn
        to="/"
        color="white"
        variant="text"
        class="text-body-2 font-weight-bold d-flex flex-column"
      >
        <v-icon class="mb-1">
          mdi-magnify
        </v-icon>
        <span>{{ t('navBar.home') }}</span>
      </v-btn>
    </template>
  </v-app-bar>
</template>
