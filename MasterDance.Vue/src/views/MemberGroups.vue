<template>
    <div class="row">
        <div class="col-md-6">
            <widget>
                <table class="table">
                    <thead>
                        <tr><th>Naziv grupe</th></tr>
                    </thead>
                    <tbody>
                        <tr v-for="group in memberGroups" class="pointer" @click="setModel(group)">
                            <td>{{group.name}}</td>
                        </tr>
                    </tbody>
                </table>
            </widget>
        </div>
        <div class="col-md-6">
            <widget>
                <div slot="actions">
                    <button class="btn btn-danger" @click="reset">Ocisti</button>
                </div>
                <div class="clearfix"></div>
                <form @submit.prevent="save" class="mt-lg">
                    <div class="form-group row" :class="{'has-error': errors.has('name')}">
                        <label class="control-label col-sm-4">Naziv grupe <span class="required">*</span></label>
                        <div class="col-sm-8">
                            <input class="form-control input-transparent" v-model="model.name" v-validate.immediate="'required'" name="name">
                        </div>
                    </div>
                    <div class="form-actions">
                        <div class="row">
                            <div class="col-sm-8 col-sm-offset-4">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-danger" :disabled="!model.id" @click="removeGroup">Obrisi</button>
                                    <button type="submit" class="btn btn-primary" :disabled="errors.any()">Potvrdi</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </widget>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import {Component, Prop, Watch} from "vue-property-decorator";
    import Widget from "@/components/common/Widget.vue";
    import notifications from '@/services/Notifications'
    import {Mutation, State} from "vuex-class";
    import {MemberGroupModel, MemberGroupsProxy} from "@/services/BackendProxies";

    @Component({
        components: {Widget}
    })
    export default class MemberGroups extends Vue {
        model = new MemberGroupModel();
        @State memberGroups;
        @Mutation setMemberGroups;

        private memberGroupsProxy = new MemberGroupsProxy();

        created() {
            this.refresh();
        }

        async refresh() {
            const data = await this.memberGroupsProxy.getMemberGroups();
            this.setMemberGroups(data);
        }

        async save() {
            try {
                const data = await this.memberGroupsProxy.saveMemberGroup(this.model);
                notifications.info('Podaci su uspesno sacuvani');
                this.setMemberGroups(data);
            } catch (err) {
                notifications.error('Greska prilikom snimanja podataka');
            }
        }

        setModel(group) {
            this.model = group;
        }

        async removeGroup() {
            try {
                const data = await this.memberGroupsProxy.deleteMemberGroupById(this.model.id);
                this.setMemberGroups(data);
                notifications.info(`Grup ${this.model.name} je uspesno obrisana`);
                this.reset();
            } catch(err) {
                console.error(err);
                notifications.error(`Neuspesno brisanje grupe ${this.model.name}. Proverite da li postoje dodeljeni clanovi`);
            }

        }

        reset() {
            this.model = new MemberGroupModel();
        }
    }
</script>

<style scoped>
</style>