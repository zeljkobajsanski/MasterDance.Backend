import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import 'jquery';
import 'bootstrap';
import datePicker from 'vue-bootstrap-datetimepicker';
import VeeValidate from 'vee-validate';
import moment from 'moment';
import * as numeral from 'numeral';
import 'select2';
import 'select2/dist/css/select2.min.css'

declare const $: any;

Vue.config.productionTip = false;
Vue.use(datePicker);
Vue.use(VeeValidate);
Vue.filter('date', (date: Date) => date ? moment(date).format('DD.MM.YYYY') : '-');
Vue.filter('money', (value: number) => numeral(value || 0).format('0,0.00'));
Vue.directive('select2', el => $(el).select2({width: '100%'}));

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
