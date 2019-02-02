<template>
    <div class="row">
        <div class="col-md-8">
            <widget>
                <div slot="actions">
                    <i class="fa fa-refresh pointer" @click="getCompetitions"></i>
                </div>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Naziv takmicenja</th>
                            <th>Datum</th>
                            <th>Mesto odrzavanja</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="competition in competitions" @click="setModel(competition)">
                            <td>{{competition.name}}</td>
                            <td>{{competition.date}}</td>
                            <td>{{competition.city}}</td>
                        </tr>
                    </tbody>
                </table>
            </widget>
        </div>
        <div class="col-md-4">
            <widget>
                <div slot="actions">
                    <button class="btn btn-danger" @click="reset">Ocisti</button>
                </div>
                <div class="clearfix"></div>
                <form class="mt-lg" @submit.prevent="save">
                    <div class="form-group row" :class="{'has-error': errors.has('name')}">
                        <label class="control-label col-sm-3">Naziv <span class="required">*</span></label>
                        <div class="col-sm-9">
                            <input class="form-control input-transparent" v-model="model.name"
                                   v-validate.immediate="'required'" name="name">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3">Datum</label>
                        <div class="col-sm-9">
                            <date-picker class="date-picker form-control input-transparent" :config="dateConfig"
                                         v-model="model.date"/>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3">Mesto</label>
                        <div class="col-sm-9">
                            <input class="form-control input-transparent" v-model="model.city">
                        </div>
                    </div>
                    <div class="form-actions">
                        <div class="row">
                            <div class="col-sm-9 col-sm-offset-3">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-danger" :disabled="!model.id" @click="removeCompetition">Obrisi</button>
                                    <button type="submit" class="btn btn-primary" :disabled="errors.any() || isSaving">Potvrdi</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
                <!--{{model}}-->
            </widget>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import {Component, Prop, Watch} from "vue-property-decorator";
    import {Action, Mutation, State} from "vuex-class";
    import Widget from "@/components/common/Widget.vue";
    import notifications from '@/services/Notifications'
    import {CompetitionModel, CompetitionsProxy} from "@/services/BackendProxies";

    @Component({
        components: {Widget}
    })
    export default class Competitions extends Vue {
        @State competitions;
        @Action getCompetitions;
        @Mutation setCompetitions;

        model = new CompetitionModel();

        dateConfig = {
            format: 'DD.MM.YYYY'
        };
        isSaving = false;

        private competitionsProxy = new CompetitionsProxy();

        created() {
            this.reset();
        }

        reset() {
            this.model = new CompetitionModel();
        }

        setModel(competition) {
            this.model = competition;
        }

        async save() {
            this.isSaving = true;
            try {
                const data = await this.competitionsProxy.saveCompetition(this.model);
                this.model.id = data;
                notifications.info('Podaci su uspesno sacuvani');
                this.isSaving = false;
                this.getCompetitions();
            } catch (err) {
                this.isSaving = false;
                notifications.error('Greska prilikom snimanja podataka');
            }
        }

        async removeCompetition() {
            const data = await this.competitionsProxy.deleteCompetition(this.model.id);
            this.setCompetitions(data);
            this.reset();
            notifications.info('Podaci su uspesno obrisani');
        }
    }
</script>

<style scoped>
    table {
        cursor: pointer;
    }
</style>