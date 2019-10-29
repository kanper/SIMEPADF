import '@babel/polyfill'
import '@mdi/font/css/materialdesignicons.css'
import Vue from 'vue'
import vuetify from "./plugins/vuetify";
import VeeValidate, {Validator} from 'vee-validate'
import es from 'vee-validate/dist/locale/es'
import App from './App.vue'
import router from './router'
import store from './store/store'

Vue.config.productionTip = false;
Validator.localize(({es: es}));
Vue.use(VeeValidate, {locale: "es"});
new Vue({
    vuetify,
    router,
    store,
    render: h => h(App)
}).$mount('#app');
