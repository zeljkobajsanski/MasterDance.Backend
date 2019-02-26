<template>
    <div>
        <!--<page-header title="Clanovi"></page-header>-->
        <widget>
            <div slot="actions">
                <router-link class="btn btn-danger btn-sm" :to="{name: 'member-edit'}">Kreiraj</router-link>
            </div>
            <div class="clearfix"></div>
            <div class="row mt-lg">
                <div class="col-sm-3" style="padding-left: 0">
                    <form>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <select class="form-control input-transparent" v-model="selectedGroup" v-select2>
                                    <option value="">Sve grupe</option>
                                    <option v-for="g in memberGroups" :value="g.id">{{g.name}}</option>
                                </select>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="col-md-12 mt-md">
                    <ul class="row thumbnails">
                        <li class="col-xs-6 col-sm-3 col-md-2 col-lg-2" v-for="member in filteredMembers" :key="member.id">
                            <div class="thumbnail">
                                <img :src="member.image || 'img/2.png'" alt="">
                                <div class="caption">
                                    <h4>{{member.firstName}} {{member.lastName}}</h4>
                                    <!--<p><strong>{{member.dateOfBirth}}</strong> You can think three hundred times and still have no precise result... </p>-->
                                    <p>
                                        <!--<a href="#" class="btn btn-danger">Favorite</a> -->
                                        <router-link :to="{name: 'member-edit', params: {id: member.id}}" class="btn btn-inverse">Detalji...</router-link>
                                    </p>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </widget>
    </div>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator'
    import PageHeader from "../components/common/PageHeader.vue";
    import Widget from "../components/common/Widget.vue";
    import {State} from "vuex-class";
    import {IMemberModel, MemberModel, MembersProxy} from "@/services/BackendProxies";


    @Component({components: {PageHeader, Widget}})
    export default class Members extends Vue {
        @State memberGroups;
        @State searchTerm;
        members: MemberModel[] = [];
        selectedGroup = '';

        private membersProxy = new MembersProxy();

        get filteredMembers() {
            let members = this.members;
            if (this.selectedGroup) {
                members = members.filter(x => +x.memberGroupId === +this.selectedGroup);
            }
            if (this.searchTerm) {
                const term = this.searchTerm.toLowerCase();
                members = members.filter(x => x.firstName.toLowerCase().indexOf(term) > -1
                    || x.lastName.toLowerCase().indexOf(term) > -1);
            }
            return members;
        }

        async created() {
            const members = await this.membersProxy.getMembers();
            this.members = members;
        }
    }
</script>

<style scoped>

</style>