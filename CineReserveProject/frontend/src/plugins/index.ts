/**
 * plugins/index.ts
 *
 * Automatically included in `./src/main.ts`
 */

// Plugins
import vuetify from './vuetify'
import router from '../router'

// Types
import type { App } from 'vue'
import i18n from './i18n'
import { createPinia } from 'pinia'
import ToastPlugin from 'vue-toast-notification'
import 'vue-toast-notification/dist/theme-sugar.css'

export function registerPlugins (app: App) {
  const pinia = createPinia()
  app
    .use(pinia)
    .use(vuetify)
    .use(router)
    .use(i18n)
    .use(ToastPlugin)
}
