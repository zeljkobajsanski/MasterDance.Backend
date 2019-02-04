<template>
    <router-view></router-view>
</template>

<script lang="ts">
import {Vue, Component, Watch} from 'vue-property-decorator'
import {State, Mutation, Action} from 'vuex-class'
import Notifications from '@/services/Notifications'

@Component({})
export default class extends Vue {
    @Action getMemberGroups;
    @Mutation setSearchTerm;

    async created() {
        await this.getMemberGroups();
    }
}
</script>


<style>
    body, label, input, button, select, textarea, .radio label, .checkbox label {
        font-weight: 100;
    }

    .btn {
        font-weight: 300;
    }

    ul.messenger-theme-air .messenger-message  {
        font-weight: 200;
    }

    .pointer {
        cursor: pointer;
    }

    .select2-container--default .select2-selection--single {
        background-color: rgba(255, 255, 255, 0.2) !important;
        border: none !important;
        color: #444;
        outline: none;
    }

    .select2-container--default .select2-results__option--highlighted[aria-selected] {
        background-color: #5897fb;
        color: white;
    }

    .select2-results__option {
        color: black;
    }

    /*.select2-dropdown {*/
        /*background-color: #7fc4f0 !important;*/
    /*}*/



    /* Change Autocomplete styles in Chrome*/
    @-webkit-keyframes autofill {
        to {
            color: #666;
            background-color: rgba(255, 255, 255, 0.3);;
        }
    }
    input:-webkit-autofill {
        -webkit-animation-name: autofill;
        -webkit-animation-fill-mode: both;
    }
</style>
