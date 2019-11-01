import * as types from './mutation-types'

const items = [{
        id: 1, displayName: "Butter Ngo"
    },{
        id: 2, displayName: "Sang De"
    }];

const actions = {
    async addUser({ commit }, payload) {
        console.log("payload ", payload);
        commit(types.LOAD_ALL_ACCOUNT, { items });
    }
};

export default actions