<template>
    <div id="app">
        <div class="logo">
            <h4>
                <router-link to="/">
                    <img src="/img/logo.png" />
                </router-link>
            </h4>
        </div>
        <nav id="sidebar" class="sidebar nav-collapse collapse">
            <ul id="side-nav" class="side-nav">
                <router-link tag="li" :to="{name: 'home'}">
                    <a><i class="fa fa-home"></i> <span class="name">Home</span></a>
                </router-link>
                <router-link :to="{name: 'groups'}" tag="li">
                    <a><i class="fa fa-users"></i> <span class="name">Grupe</span>
                    </a>
                </router-link>
                <router-link :to="{name: 'members'}" tag="li">
                    <a><i class="fa fa-user"></i> <span class="name">Clanovi</span>
                    </a>
                </router-link>
                <router-link :to="{name: 'competitions'}" tag="li">
                    <a><i class="fa fa-calendar"></i>
                        <span class="name">Takmicenja
                            <!--<sup class="text-warning fw-bold"> New</sup>-->
                        </span>
                    </a>
                </router-link>
                <router-link :to="{name: 'balance'}" tag="li">
                    <a><i class="fa fa-money"></i>
                        <span class="name">Uplate
                            <!--<sup class="text-warning fw-bold"> New</sup>-->
                        </span>
                    </a>
                </router-link>
                <!-- <router-link :to="{name: 'schedule'}" tag="li">
                     <a><i class="fa fa-calendar"></i>
                         <span class="name">Raspored
                             &lt;!&ndash;<sup class="text-warning fw-bold"> New</sup>&ndash;&gt;
                         </span>
                     </a>
                 </router-link>-->
            </ul>
        </nav>
        <div class="wrap">
            <header class="page-header">
                <div class="navbar">
                    <ul class="nav navbar-nav navbar-right pull-right">
                        <li class="visible-phone-landscape">
                            <a href="#" id="search-toggle">
                                <i class="fa fa-search"></i>
                            </a>
                        </li>
                       <!-- <li class="dropdown">
                            <a href="#" title="Messages" id="messages"
                               class="dropdown-toggle"
                               data-toggle="dropdown">
                                <i class="glyphicon glyphicon-comment"></i>
                            </a>
                            <ul id="messages-menu" class="dropdown-menu messages" role="menu">
                                <li role="presentation">
                                    <a href="#" class="message">
                                        <img src="img/1.png" alt="">
                                        <div class="details">
                                            <div class="sender">Jane Hew</div>
                                            <div class="text">
                                                Hey, John! How is it going? ...
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="message">
                                        <img src="img/2.png" alt="">
                                        <div class="details">
                                            <div class="sender">Alies Rumiancaŭ</div>
                                            <div class="text">
                                                I'll definitely buy this template
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="message">
                                        <img src="img/3.png" alt="">
                                        <div class="details">
                                            <div class="sender">Michał Rumiancaŭ</div>
                                            <div class="text">
                                                Is it really Lore ipsum? Lore ...
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="text-align-center see-all">
                                        See all messages <i class="fa fa-arrow-right"></i>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" title="8 support tickets"
                               class="dropdown-toggle"
                               data-toggle="dropdown">
                                <i class="glyphicon glyphicon-globe"></i>
                                <span class="count">8</span>
                            </a>
                            <ul id="support-menu" class="dropdown-menu support" role="menu">
                                <li role="presentation">
                                    <a href="#" class="support-ticket">
                                        <div class="picture">
                                            <span class="label label-important"><i class="fa fa-bell-o"></i></span>
                                        </div>
                                        <div class="details">
                                            Check out this awesome ticket
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="support-ticket">
                                        <div class="picture">
                                            <span class="label label-warning"><i
                                                    class="fa fa-question-circle"></i></span>
                                        </div>
                                        <div class="details">
                                            "What is the best way to get ...
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="support-ticket">
                                        <div class="picture">
                                            <span class="label label-success"><i class="fa fa-tag"></i></span>
                                        </div>
                                        <div class="details">
                                            This is just a simple notification
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="support-ticket">
                                        <div class="picture">
                                            <span class="label label-info"><i class="fa fa-info-circle"></i></span>
                                        </div>
                                        <div class="details">
                                            12 new orders has arrived today
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="support-ticket">
                                        <div class="picture">
                                            <span class="label label-important"><i class="fa fa-plus"></i></span>
                                        </div>
                                        <div class="details">
                                            One more thing that just happened
                                        </div>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="text-align-center see-all">
                                        See all tickets <i class="fa fa-arrow-right"></i>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="divider"></li>
                        <li class="hidden-xs">
                            <a href="#" id="settings"
                               title="Settings"
                               data-toggle="popover"
                               data-placement="bottom">
                                <i class="glyphicon glyphicon-cog"></i>
                            </a>
                        </li>
                        <li class="hidden-xs dropdown">
                            <a href="#" title="Account" id="account"
                               class="dropdown-toggle"
                               data-toggle="dropdown">
                                <i class="glyphicon glyphicon-user"></i>
                            </a>
                            <ul id="account-menu" class="dropdown-menu account" role="menu">
                                <li role="presentation" class="account-picture">
                                    <img src="img/2.png" alt="">
                                    Philip Daineka
                                </li>
                                <li role="presentation">
                                    <a href="form_account.html" class="link">
                                        <i class="fa fa-user"></i>
                                        Profile
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="component_calendar.html" class="link">
                                        <i class="fa fa-calendar"></i>
                                        Calendar
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#" class="link">
                                        <i class="fa fa-inbox"></i>
                                        Inbox
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="visible-xs">
                            <a href="#"
                               class="btn-navbar"
                               data-toggle="collapse"
                               data-target=".sidebar"
                               title="">
                                <i class="fa fa-bars"></i>
                            </a>
                        </li>-->
                        <li class="hidden-xs"><a @click="logout"><i class="glyphicon glyphicon-off"></i></a></li>
                    </ul>
                    <form id="search-form" class="navbar-form pull-right" role="search" @submit.prevent="setSearchTerm($refs.searchText.value)">
                        <input type="search" class="form-control search-query" placeholder="Search..." ref="searchText">
                    </form>
                </div>
            </header>
            <div class="content container">
                <router-view></router-view>
                <footer class="content-footer">
                    Master Dance - Made with love by <a href="mailto:zeljko.bajsanski@bitseverywhere.rs">bitsEverywhere</a>
                </footer>
            </div>
            <div class="loader-wrap hiding hide">
                <i class="fa fa-circle-o-notch fa-spin"></i>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import {Prop, Component, Watch} from 'vue-property-decorator';
    import authProxy from '@/services/AuthenticationProxy'

    @Component({})
    export default class PageWrapper extends Vue {

        logout() {
            authProxy.logout();
            this.$router.push('/login');
        }
    }
</script>

<style scoped>

</style>