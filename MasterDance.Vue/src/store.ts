import Vue from 'vue'
import Vuex from 'vuex'
import {IMemberGroupModel, MemberGroupsProxy} from "@/services/BackendProxies";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        memberGroups: <IMemberGroupModel[]>[],
        searchTerm: null
    },
    mutations: {
        setMemberGroups: (state, memberGroups: IMemberGroupModel[]) => {
            state.memberGroups = memberGroups;
        },
        setSearchTerm: (state, term) => {
            state.searchTerm = term;
            console.log(term);
        }
    },
    actions: {
        async getMemberGroups({commit}) {
            const memberGroups = await new MemberGroupsProxy().getMemberGroups();
            commit('setMemberGroups', memberGroups);
        }
    }
})
