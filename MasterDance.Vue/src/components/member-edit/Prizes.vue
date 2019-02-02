<template>
    <div>
        <modal-dialog title="Dodaj nagradu" ref="dialog" @accepted="save">
            <form>
                <div class="form-group row">
                    <label class="control-label col-sm-3">Takmicenje</label>
                    <div class="col-sm-9">
                        <select class="form-control" v-model="model.competitionId">
                            <option value="">-</option>
                            <option v-for="(c) in competitions" :key="c.id" :value="c.id">{{c.name}}</option>
                        </select>
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 control-label">Kategorija</label>
                    <div class="col-sm-9">
                        <input class="form-control" v-model="model.category">
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 control-label">Koreografija</label>
                    <div class="col-sm-9">
                        <input class="form-control" v-model="model.choreography">
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-sm-3 control-label">Osvojena nagrada</label>
                    <div class="col-sm-9">
                        <input class="form-control" v-model="model.title">
                    </div>
                </div>
            </form>
        </modal-dialog>

        <table class="table">
            <thead>
            <tr>
                <th>Datum</th>
                <th>Takmicenje</th>
                <th>Nagrada</th>
                <th></th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="prize in data">
                <td>{{prize.competitionDate}}</td>
                <td>{{prize.competitionName}}</td>
                <td>{{prize.title}}</td>
                <td>
                    <div class="btn-group">
                        <button class="btn btn-xs btn-inverse" title="Izmeni" @click="edit(prize)"><i class="fa fa-pencil"></i> </button>
                        <button class="btn btn-xs btn-inverse" title="Obrisi" @click="removePrize(prize)"><i class="fa fa-trash"></i> </button>
                    </div>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import {Component, Prop, Watch} from "vue-property-decorator";
    import ModalDialog from "@/components/common/ModalDialog.vue";
    import {State} from "vuex-class";
    import {CompetitionModel, CompetitionsProxy, MembersProxy, PrizeModel} from "@/services/BackendProxies";

    //TODO: Category, Choreography
    @Component({
        components: {ModalDialog}
    })
    export default class Prizes extends Vue {
        @Prop() memberId: number;
        data: PrizeModel[] = [];
        model = new PrizeModel();
        competitions: CompetitionModel[] = [];

        private membersProxy = new MembersProxy();
        private competitionsProxy = new CompetitionsProxy();

        async created() {
            this.competitions = await this.competitionsProxy.getCompetitions();
        }

        @Watch('memberId')
        async onMemberIdChanged(id) {
            const data = await this.membersProxy.getPrizes(id);
            this.data = data;
        }

        addPrize() {
            this.model = new PrizeModel();
            (<ModalDialog>this.$refs.dialog).open();
        }

        async save() {
            try {
                const prize = this.model.clone();
                prize.memberId = this.memberId;
                const data = await this.membersProxy.savePrize(this.memberId, prize);
                this.data = data;
                (<ModalDialog>this.$refs.dialog).close();
            } catch (err) {

            }
        }

        edit(prize: PrizeModel) {
            this.model = prize;
            (<ModalDialog>this.$refs.dialog).open();
        }

        async removePrize(prize: PrizeModel) {
            const data = await this.membersProxy.deletePrize(this.memberId, prize.id);
            this.data = data;
        }
    }
</script>

<style scoped>

</style>