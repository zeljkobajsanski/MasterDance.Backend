<template>
    <widget title="Upozorenja">
        <div slot="actions">
            <i class="fa fa-refresh pointer" @click="refresh"></i>
        </div>
        <p v-if="data.length === 0">Nema aktivnih upozorenja</p>
        <table class="table" v-else>
            <thead>
                <tr>
                    <td>Ime clana</td>
                    <td>Vrsta upozorenja</td>
                    <td>Datum isteka</td>
                    <td>Rok</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="notification in data">
                    <td>
                        <router-link :to="{name: 'member-edit', params: {id: notification.memberId}}">{{notification.member}}</router-link>
                    </td>
                    <td>{{notification.notificationType}}</td>
                    <td>{{notification.date}}</td>
                    <td>{{notification.daysDiff}}</td>
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
    export default class Notifications extends Vue {
        data = [];

        created() {
            this.refresh();
        }

        async refresh() {
            /*const {data} = await api.getNotifications(); //TODO: Implement this
            this.data = data;*/
        }
    }
</script>

<style scoped>

</style>