<template>
    <widget>
        <table class="table" v-table="tableOptions">

        </table>
    </widget>
</template>

<script lang="ts">
    import Vue from 'vue'
    import {Component, Prop, Watch} from "vue-property-decorator";
    import Widget from "@/components/common/Widget.vue";
    import {IMembershipsAndPayments, MembershipsProxy} from "@/services/BackendProxies";
    import {formatMoney} from "@/utils";

    @Component({
        components: {Widget}
    })
    export default class BalanceSheet extends Vue {
        tableOptions = {
          columns: [
              { field: 'member', title: 'Ime i prezime', formatter: (v, row) => `<a href="#/members/${row.memberId}/details">${row.member}</a>` },
              { title: 'Mesec', formatter: (v, row) => `${row.month}/${row.year}` },
              { field: 'description', title: 'Opis' },
              { field: 'amount', title: 'Zaduzenje', formatter: (value) => formatMoney(value), align: 'right' },
              { field: 'paidAmount', title: 'Uplata', formatter: (value) => formatMoney(value), align: 'right' },
              { field: 'difference', title: 'Stanje', formatter: (value) => formatMoney(value), align: 'right' },
          ],
          data: [],
            pagination: true,
            search: true
        };
        private membershipsProxy = new MembershipsProxy();

        async created() {
            const data = await this.membershipsProxy.getMembershipsAndPayments();
            this.tableOptions = {...this.tableOptions, data};
        }
    }
</script>

<style scoped>

</style>