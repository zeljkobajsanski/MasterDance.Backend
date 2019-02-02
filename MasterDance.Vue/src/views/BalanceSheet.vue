<template>
    <widget>
        <table class="table">
            <thead>
                <tr>
                    <th>Ime clana</th>
                    <th>Ukupno zaduzenje</th>
                    <th>Ukupna uplata</th>
                    <th>Stanje</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="i in data">
                    <td>
                        <router-link :to="{name: 'member-edit', params: {id: i.memberId}}">{{i.member}}</router-link>
                    </td>
                    <td>{{i.totalAmount | money}}</td>
                    <td>{{i.totalPaid | money}}</td>
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

    @Component({
        components: {Widget}
    })
    export default class BalanceSheet extends Vue {
        data = [];

        async created() {
            /*const {data} = await api.getBalanceSheet(); //TODO: Implement balance sheet
            this.data = data;*/
        }
    }
</script>

<style scoped>

</style>