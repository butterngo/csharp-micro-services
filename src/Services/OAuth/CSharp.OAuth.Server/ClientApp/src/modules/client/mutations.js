import * as types from './mutation-types';

const mutations = {
    [types.LOAD_ALL_ACCOUNT] (state) {
      console.log("LOAD_ALL_ACCOUNT", state);
    }
};
  
export default mutations ;