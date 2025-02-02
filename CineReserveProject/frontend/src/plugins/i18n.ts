import { createI18n } from "vue-i18n"
import { en, fr } from "vuetify/locale"
import frFR from "@/locales/fr-FR.json"
import enUS from "@/locales/en-US.json"

const messages = {
  "fr-FR": {
    ...frFR,
    $vuetify: { ...fr },
  },
  "en-US":{
    ...enUS,
    $vuetify: { ...en }
  }
}

const i18n = createI18n({
  // Set locale.
  locale: navigator.language,

  // Set fallback locale.
  fallbackLocale: "fr-FR",

  // Must be set to 'false', to use Composition API.
  legacy: false,

  // Refer a global scope Composer instance of i18n.
  globalInjection: true,

  // Set locale messages
  messages
})

export default i18n
