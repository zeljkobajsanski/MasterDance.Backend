<template>
    <div>
        <!--<page-header title="Home"></page-header>-->
        <div class="row">
            <div class="col-md-4">
                <widget title="Ukupno clanova">
                    <h1 class="stats">{{totalMembers}}</h1>
                </widget>
            </div>
            <div class="col-md-4">
                <widget title="Prihod od clanarine">
                    <h1 class="stats">{{profit | money}} RSD</h1>
                </widget>
            </div>
            <div class="col-md-4">
                <widget title="Dugovanja">
                    <h1 class="stats">{{totalDebt | money}} RSD</h1>
                </widget>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <debt-list />
            </div>
            <div class="col-md-6">
                <notifications />
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import widget from '@/components/common/Widget.vue';
import PageHeader from "../components/common/PageHeader.vue";
import debtList from '@/components/home/due-list.vue'
import notifications from '@/components/home/notifications.vue'
import {DashboardProxy} from "@/services/BackendProxies";

@Component({
    components: {notifications, PageHeader, widget, debtList}
})
export default class Home extends Vue {
    totalMembers = 0;
    profit = 0;
    totalDebt = 0;

    private dashboardProxy = new DashboardProxy();

    async created() {
        const data = await this.dashboardProxy.getDashboard();
        this.totalMembers = data.totalMembers;
        this.totalDebt = data.debit;
        this.profit = data.profit;
    }
}
</script>

<style scoped>
    .stats {
        font-weight: 200;
    }
</style>
