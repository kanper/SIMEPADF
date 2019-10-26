import Vue from 'vue'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import es from 'vuetify/src/locale/es.ts'

Vue.use(Vuetify, {
  iconfont: 'mdi',
  lang: {
    locales: {es},
    current: 'es'
  }
});

const opts = {}

export default new Vuetify(opts)