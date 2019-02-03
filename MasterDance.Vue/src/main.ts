import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import 'jquery';
import 'bootstrap';
import datePicker from 'vue-bootstrap-datetimepicker';
import VeeValidate from 'vee-validate';
import moment from 'moment';
import 'moment/locale/sr'
import * as numeral from 'numeral';
import Select2 from './plugins/select2.plugin';
import BoostrapTable from './plugins/bootstrap-table.plugin'


declare const $: any;

Vue.config.productionTip = false;
Vue.use(datePicker);
Vue.use(VeeValidate);
Vue.filter('date', (date: Date) => date ? moment(date).format('DD.MM.YYYY') : '-');
Vue.filter('money', (value: number) => numeral(value || 0).format('0,0.00'));
Vue.use(Select2);
Vue.use(BoostrapTable);

moment.locale('sr');

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
