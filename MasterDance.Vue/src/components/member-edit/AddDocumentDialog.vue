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
        </form>
    </modal-dialog>
</template>

<script lang="ts">
    import {Vue, Component, Prop, Emit} from 'vue-property-decorator';
    import ModalDialog from '@/components/common/ModalDialog.vue';

    import moment from "moment";
    import {
        DocumentsProxy,
        DocumentTypeModel,
        DocumentTypesProxy, MemberModel,
        MembersProxy
    } from "@/services/BackendProxies";
    import {convertStringToDateFormat} from "../../utils";
    import {FileParameter} from "../../services/BackendProxies";

    @Component({components: {ModalDialog}})
    export default class AddDocumentDialog extends Vue {
        @Prop() member: MemberModel;
        documentTypes: DocumentTypeModel[] = [];
        document: {documentTypeId: number, date: string, file: FileParameter} = {documentTypeId: 1, date: null, file: null};

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
                this.document.file = {fileName: files[0].name, data: files[0]}
            }
        }

        @Emit('saved') onSaved() {

        }

        async saveDocument() {
            const data = await this.membersProxy.uploadDocument(
                this.member.id, this.document.documentTypeId, convertStringToDateFormat(this.document.date), this.document.file, this.member.id);
            this.onSaved();
            (<ModalDialog>this.$refs['dialog']).close();
        }
    }
</script>

<style scoped>

</style>