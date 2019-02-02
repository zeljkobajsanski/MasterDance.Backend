<template>
    <widget title="Duznici">
        <div slot="actions">
            <i class="fa fa-refresh pointer" @click="refresh"></i>
        </div>
        <p v-if="data.length === 0">Sve obaveze su izmirene.</p>
        <table v-else class="table">
            <thead>
            <tr>
                <th>Ime clana</th>
                <!--<th>Ukupno zaduzenje</th>-->
                <!--<th>Ukupna uplata</th>-->
                <th>Dug</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="i in data">
                <td>
                    <router-link :to="{name: 'member-edit', params: {id: i.memberId}}">{{i.member}}</router-link>
                </td>
                <!--<td>{{i.totalAmount}}</td>-->
                <!--<td>{{i.totalPaid}}</td>-->
                <td :class="{'text-danger': i.balance < 0}">{{i.balance | money}}</td>
            </tr>
            </tbody>
        </table>
    </widget>
</template>

<script lang="ts">
    import Vue from 'vue'
    import {Component, Prop, Watch} from "vue-property-decorator";
    import Widget from "@/components/common/Widget.vue";
    import {MembershipsProxy} from "@/services/BackendProxies";

    @Component({
        components: {Widget}
    })
    export default class DueList extends Vue {
        data = [];

        private membershipsProxy = new MembershipsProxy();

        created() {
            this.refresh();
        }

        async refresh() {
            this.data = await this.membershipsProxy.getDebtList();
        }
    }
</script>

<style scoped>

</style>