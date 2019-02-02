import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Members from '@/views/Members.vue';
import MemberEdit from '@/views/MemberEdit.vue';
import Competitions from '@/views/Competitions.vue';
import BalanceSheet from '@/views/BalanceSheet.vue'
import MemberGroups from '@/views/MemberGroups.vue'

Vue.use(Router);

export default new Router({
    linkActiveClass: 'active',
    routes: [
        {
            path: '/home',
            name: 'home',
            component: Home
        },
        {path: '/', redirect: '/home'},
        {path: '/members', name: 'members', component: Members},
        {path: '/members/:id?/details', name: 'member-edit', component: MemberEdit},
        {path: '/members/create', name: 'member-edit', component: MemberEdit},
        {path: '/competitions', name: 'competitions', component: Competitions},
        {path: '/balance', name: 'balance', component: BalanceSheet},
        {path: '/groups', name: 'groups', component: MemberGroups},
    ]
})
