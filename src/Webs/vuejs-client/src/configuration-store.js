import Vue from "vue";
import Vuex from "vuex";
import VuexI18n from "vuex-i18n"; // load vuex i18n module
import { account } from './modules';

Vue.use(Vuex);
const store = new Vuex.Store({
  strict: true, // process.env.NODE_ENV !== 'production',
  modules: {
    account,
  }
});

Vue.use(VuexI18n.plugin, store);

export default store;
