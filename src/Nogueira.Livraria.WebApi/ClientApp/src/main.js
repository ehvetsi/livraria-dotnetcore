import '@babel/polyfill'
import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from "./router"
import moment from "moment"
import plugins from './plugins/util.js'
Vue.use(plugins);

moment.locale("pt-br")
window.moment=moment
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
