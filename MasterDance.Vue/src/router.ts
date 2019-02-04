import Vue from 'vue'
import Router from 'vue-router'
import PageWrapper from '@/components/page-wrapper.vue'
import Home from './views/Home.vue'
import Members from '@/views/Members.vue';
import MemberEdit from '@/views/MemberEdit.vue';
import Competitions from '@/views/Competitions.vue';
import BalanceSheet from '@/views/BalanceSheet.vue'
import MemberGroups from '@/views/MemberGroups.vue'
import Login from '@/views/Login.vue'
import authProxy from '@/services/AuthenticationProxy'

Vue.use(Router);

const authGuard = (to, from, next) => {
    if (authProxy.isAuthenticated()) {
        next();
    } else {
        next('/login');
    }
};

export default new Router({
    linkActiveClass: 'active',
    routes: [

        {path: '/', component: PageWrapper, children: [
            {path: '/home', name: 'home', component: Home, beforeEnter: authGuard},
            {path: '/members', name: 'members', component: Members, beforeEnter: authGuard},
            {path: '/members/:id?/details', name: 'member-edit', component: MemberEdit, beforeEnter: authGuard},
            {path: '/members/create', name: 'member-edit', component: MemberEdit, beforeEnter: authGuard},
            {path: '/competitions', name: 'competitions', component: Competitions, beforeEnter: authGuard},
            {path: '/balance', name: 'balance', component: BalanceSheet, beforeEnter: authGuard},
            {path: '/groups', name: 'groups', component: MemberGroups, beforeEnter: authGuard},
            {path: '/', redirect: '/home'},
        ]},
        {path: '/login', name: 'login', component: Login}
    ]
});


