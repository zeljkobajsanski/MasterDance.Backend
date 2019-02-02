<template>
    <modal-dialog title="Dodaj dokument" ref="dialog" @accepted="saveDocument()">
        <form class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-sm-3">Tip dokumenta</label>
                <div class="col-sm-9">
                    <select class="form-control" v-model="document.documentTypeId">
                        <option v-for="dt in documentTypes" :value="dt.id" :key="dt.id">{{dt.name}}</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3">Datum vazenja</label>
                <div class="col-sm-9">
                    <date-picker :config="dateConfig" v-model="document.date"></date-picker>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3">Dokument</label>
                <div class="col-sm-9">
                    <input type="file" class="form-control" @change="onFileSelected($event.target.files)"/>
                </div>
            </div>
            {{document}}
        </form>
    </modal-dialog>
</template>

<script lang="ts">
    import {Vue, Component, Prop, Emit} from 'vue-property-decorator';
    import ModalDialog from '@/components/common/ModalDialog.vue';

    import moment from "moment";
    import {
        DocumentForUpload,
        DocumentsProxy,
        DocumentTypeModel,
        DocumentTypesProxy, MemberModel,
        MembersProxy
    } from "@/services/BackendProxies";

    @Component({components: {ModalDialog}})
    export default class AddDocumentDialog extends Vue {
        @Prop() member: MemberModel;
        documentTypes: DocumentTypeModel[] = [];
        document = DocumentForUpload.fromJS({documentTypeId: 1});

        dateConfig = {
            format: 'DD.MM.YYYY'
        };

        private documentTypesProxy = new DocumentTypesProxy();
        private documentsProxy = new DocumentsProxy();
        private membersProxy = new MembersProxy();

        async created() {
            const data = await this.documentTypesProxy.getDocumentTypes();
            this.documentTypes = data;
        }

        show() {
            (<ModalDialog>this.$refs['dialog']).open();
        }

        onFileSelected(files: FileList) {
            if (files.length > 0) {
                this.document.file = files[0];
            }
        }

        @Emit('saved') onSaved() {

        }

        async saveDocument() {
            /*const fd = new FormData();
            fd.append('memberId', this.member.id);
            fd.append('documentTypeId', this.documentTypeId);
            if (this.date) {
                fd.append('date', moment(this.date, this.dateConfig.format).format('YYYY-MM-DD'));
            }
            fd.append('file', this.file);*/
            const document = this.document.clone();
            document.memberId = this.member.id;

            const data = await this.membersProxy.uploadDocument(this.member.id, document);
            this.onSaved();
            (<ModalDialog>this.$refs['dialog']).close();
        }
    }
</script>

<style scoped>

</style>