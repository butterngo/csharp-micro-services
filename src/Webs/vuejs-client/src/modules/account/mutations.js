import * as types from './mutation-types'

const state = {
    accounts: [],
};

const mutations = {
    [types.LOAD_ALL_ACCOUNT] (state) {
      console.log("LOAD_ALL_ACCOUNT", state);
    }
};
  
export default { state, mutations };