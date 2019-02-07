<template>
    <div>
        <!--<page-header title="Clan kluba"/>-->
        <div class="row">
            <div class="col-md-5">
                <widget>
                    <form class="form-horizontal form-label-left" @submit.prevent="save">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="text-align-center">
                                    <img class="img-responsive" :src="member.image || 'img/2.png'" @click="showImageEditor()" style="height: 112px;">
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <h3 class="mt-sm mb-xs">{{member.firstName}} {{member.lastName}}</h3>
                                <address>
                                    <!--<strong>Development manager</strong> at <strong><a href="#">Allexample Inc.</a></strong><br>-->
                                    <abbr title="Adresa">Adresa:</abbr> {{member.contactAddress}}<br>
                                    <abbr title="Telefon">Telefon:</abbr> {{member.contactPhone}}<br>
                                    <abbr title="Roditelj">Roditelj:</abbr> {{parent}}
                                </address>
                            </div>
                        </div>
                        <!--<fieldset class="mt-sm">-->
                            <!--<legend>Podaci clana </legend>-->
                        <!--</fieldset>-->
                        <fieldset>
                            <legend class="section">Licni Podaci</legend>
                            <!--<div class="form-group">-->
                                <!--<label class="control-label col-sm-4" for="prefix">Prefix</label>-->
                                <!--<div class="col-sm-4"><input type="text" id="prefix" name="prefix" class="form-control input-transparent"></div>-->
                            <!--</div>-->
                            <div class="form-group" :class="{'has-error': errors.has('first-name')}">
                                <label class="control-label col-sm-4" for="first-name">Ime <span class="required">*</span></label>
                                <div class="col-sm-8">
                                    <input type="text" id="first-name" name="first-name"
                                           class="form-control input-transparent" v-model="member.firstName" v-validate.immediate="'required'"></div>
                            </div>
                            <div class="form-group" :class="{'has-error': errors.has('last-name')}">
                                <label class="control-label col-sm-4" for="last-name">Prezime <span class="required">*</span></label>
                                <div class="col-sm-8">
                                    <input type="text" id="last-name" name="last-name" class="form-control input-transparent"
                                           v-model="member.lastName" v-validate.immediate="'required'"></div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">Pol</label>
                                <div class="col-sm-4">
                                    <div class="radio radio-primary">
                                        <input type="radio" id="female" name="gender" :value="Gender.Female" v-model="member.gender">
                                        <label for="female"> Devojcica</label>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="radio radio-primary">
                                        <input type="radio" id="male" name="gender" :value="Gender.Male" v-model="member.gender">
                                        <label for="male"> Decak</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group" :class="{'has-error': errors.has('date-of-birth')}">
                                <label class="control-label col-sm-4">Datum rodjenja <span class="required">*</span></label>
                                <div class="col-sm-8">
                                    <date-picker class="date-picker form-control input-transparent"
                                                 :config="dateConfig"
                                                 name="date-of-birth" v-model="member.dateOfBirth" v-validate.immediate="'required'"/></div>
                            </div>
                            <div class="form-group" :class="{'has-error': errors.has('jmbg')}">
                                <label class="control-label col-sm-4" for="last-name">JMBG </label>
                                <div class="col-sm-8">
                                    <input type="text" id="jmbg" name="jmbg" class="form-control input-transparent"
                                           v-model="member.jmbg" v-validate.immediate="'length:13'"></div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">Pripada grupi </label>
                                <div class="col-sm-8">
                                    <select class="form-control input-transparent" v-select2 v-model="member.memberGroupId">
                                        <option value="">-</option>
                                        <option v-for="g in memberGroups" :key="g.id" :value="g.id">{{g.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">Članarina</label>
                                <div class="col-sm-8">
                                    <select class="form-control input-transparent" v-select2="paymentCategoriesOptions" v-model="member.paymentCategoryId">
                                        <option value="">-</option>
                                        <option v-for="c in paymentCategories" :key="c.id" :value="c.id">{{c.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">Clan od </label>
                                <div class="col-sm-8">
                                    <date-picker class="date-picker form-control input-transparent"
                                                 :config="dateConfig"
                                                 name="date-of-birth" v-model="member.joinedDate" /></div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">Dodatne aktivnosti</label>
                                <div class="col-sm-8">
                                    <div class="checkbox checkbox-primary">
                                        <input type="checkbox" id="gym" name="gender" v-model="member.attendGymnastics">
                                        <label for="gym"> Gimnastika</label>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend class="section">Kontakt</legend>
                            <div class="form-group">
                                <label for="address" class="control-label col-sm-4">Adresa </label>
                                <div class="col-sm-8">
                                    <input id="address" type="text"
                                           data-trigger="change"
                                           class="form-control input-transparent"
                                           name="address" v-model="member.contactAddress">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="phone" class="control-label col-sm-4">Telefon </label>
                                <div class="col-sm-8">
                                    <input id="phone" class="form-control input-transparent"
                                           type="text"
                                           name="phone" v-model="member.contactPhone">
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend class="section">Otac</legend>
                            <div class="form-group">
                                <label for="father-fname" class="control-label col-sm-4">Ime </label>
                                <div class="col-xs-12 col-sm-8">
                                    <input id="father-fname" class="form-control input-transparent  mask"
                                           type="text"
                                           name="fatherFirstName" v-model="member.fatherFirstName">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="father-phone" class="control-label col-sm-4">Telefon </label>
                                <div class="col-xs-12 col-sm-8">
                                    <input id="father-phone" class="form-control input-transparent  mask"
                                           type="text"
                                           name="fatherContactPhone" v-model="member.fatherContactPhone">
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend class="section">Majka</legend>
                            <div class="form-group">
                                <label for="mother-fname" class="control-label col-sm-4">Ime </label>
                                <div class="col-xs-12 col-sm-8">
                                    <input id="mother-fname" class="form-control input-transparent  mask"
                                           type="text"
                                           name="motherFirstName" v-model="member.motherFirstName">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="mother-phone" class="control-label col-sm-4">Telefon </label>
                                <div class="col-xs-12 col-sm-8">
                                    <input id="mother-phone" class="form-control input-transparent  mask"
                                           type="text"
                                           name="motherContactPhone" v-model="member.motherContactPhone">
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-sm-8 col-sm-offset-4">
                                    <div class="btn-group">
                                        <router-link :to="{name: 'members'}" class="btn btn-success">Lista clanova</router-link>
                                        <button type="submit" class="btn btn-primary" :disabled="errors.any() || isSaving">Potvrdi</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </widget>
            </div>
            <div class="col-md-7">
                <widget>
                    <tabs>
                        <tab title="Dokumenta">
                            <documents-table :documents="documents" :member="member"></documents-table>
                        </tab>
                        <tab title="Nagrade">
                            <widget>
                                <div slot="actions">
                                    <button class="btn btn-danger" @click="addPrize">Dodaj nagradu</button>
                                    <div class="clearfix"></div>
                                </div>
                                <prizes :memberId="member.id" class="mt-lg" ref="prizes"/>
                            </widget>
                        </tab>
                        <tab title="Clanarina">
                            <memberships :memberId="member.id" />
                        </tab>
                    </tabs>
                </widget>
            </div>
        </div>
        <image-edit-modal ref="imageEditor" v-model="member.image"/>
    </div>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator';
    import PageHeader from '@/components/common/PageHeader.vue';
    import Widget from '@/components/common/Widget.vue';
    import {Gender} from "../types";
    import notifications from '@/services/Notifications';
    import ImageEditModal from '@/components/ImageEditModal.vue';
    import Tabs from '@/components/common/Tabs.vue';
    import Tab from '@/components/common/Tab.vue';
    import AddDocumentDialog from '@/components/member-edit/AddDocumentDialog.vue';
    import documentsTable from '@/components/member-edit/DocumentsTable.vue';
    import prizes from '@/components/member-edit/Prizes.vue'
    import Memberships from '@/components/member-edit/Memberships.vue'
    import {State} from "vuex-class";
    import {
        DocumentsProxy,
        DocumentTypesProxy, IPaymentCategoryModel,
        MemberDetailsModel,
        MembersProxy,
        PaymentCategoriesProxy
    } from "@/services/BackendProxies";

    @Component({components: {PageHeader, Widget, ImageEditModal, Tabs, Tab, AddDocumentDialog, documentsTable, prizes, Memberships}})
    export default class MemberEdit extends Vue {
        @State memberGroups;
        member = MemberDetailsModel.fromJS({gender: Gender.Female});
        Gender = Gender;
        isSaving = false;
        documents = [];
        dateConfig = {
            format: 'DD.MM.YYYY',
            locale: 'sr',
            useCurrent: false
        };
        paymentCategories: IPaymentCategoryModel[] = [];
        paymentCategoriesOptions = {};

        private membersProxy = new MembersProxy();
        private documentsProxy = new DocumentsProxy();
        private documentTypesProxy = new DocumentTypesProxy();
        private paymentCategoriesProxy = new PaymentCategoriesProxy();

        async created() {
            this.paymentCategories = await this.paymentCategoriesProxy.getPaymentCategories();

            const memberId = +this.$route.params['id'];
            if (memberId) {
                const data = await this.membersProxy.getMember(memberId);
                this.member = data;
                await this.refreshDocuments();
            }
            setTimeout(async () => {

            }, 3000);
        }

        async save() {
            try {
                this.isSaving = true;
                const member = this.member.clone();
                const data = await this.membersProxy.saveMember(member);
                this.member = data;
                notifications.info('Podaci su uspesno sacuvani');
            } catch(e) {
                notifications.error('Greska prilikom unosa podataka');
            }
            this.isSaving = false;

        }

        showImageEditor() {
            (<ImageEditModal>this.$refs['imageEditor']).show();
        }

        async refreshDocuments() {
            const data = await this.membersProxy.getDocuments(this.member.id);
            this.documents = data;
        }

        get parent() {
            if (this.member.motherFirstName) {
                return `${this.member.motherFirstName} ${this.member.motherContactPhone}`
            } else if (this.member.fatherFirstName) {
                return `${this.member.fatherFirstName} ${this.member.fatherContactPhone}`
            }
            return '-';
        }

        addPrize() {
            (<prizes>this.$refs.prizes).addPrize();
        }
    }
</script>

<style scoped>

</style>