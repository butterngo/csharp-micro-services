import actions from './actions';
import { state, mutations} from './mutations';

const getters = {
    items: state => state.items,
};

export default { 
    getters,
    actions,
    state,
    mutations
};