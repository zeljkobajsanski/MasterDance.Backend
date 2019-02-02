<template>
    <div>
        <modal-dialog title="Dodaj nagradu" ref="dialog" @accepted="save">
            <form>
                <div class="form-group row">
                    <label class="control-label col-sm-3">Takmicenje</label>
                    <div class="col-sm-9">
                        <select class="form-control" v-model="model.competitionId">
                            <option v-for="c in competitions" :value="c.id">{{c.name}}</option>
                        </select>
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
    import {MembersProxy, PrizeModel} from "@/services/BackendProxies";

    @Component({
        components: {ModalDialog}
    })
    export default class Prizes extends Vue {
        @Prop() memberId: number;
        @State competitions;
        data: PrizeModel[] = [];
        model = new PrizeModel();

        private membersProxy = new MembersProxy();

        @Watch('memberId')
        async onMemberIdChanged(id) {
            const data = await this.membersProxy.getPrizes(id);
            this.data = data;
        }

        addPrize() {
            this.model = this.model;
            (<ModalDialog>this.$refs.dialog).open();
        }

        async save() {
            try {
                const data = await this.membersProxy.savePrize(this.memberId, this.model);
                this.data = data;
                (<ModalDialog>this.$refs.dialog).close();
            } catch (err) {

            }
        }

        edit(prize) {
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