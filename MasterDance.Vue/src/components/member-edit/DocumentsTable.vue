<template>
    <div>
        <add-document-dialog ref="addDocumentDialog" :member="member" @saved="refreshDocuments()"></add-document-dialog>
        <modal-dialog ref="documentPreview" title="Pregled dokumenta">
            <object :data="previewDocumentUrl" width="100%" height="600"></object>
        </modal-dialog>
        <widget>
            <table class="table">
                <thead>
                <tr>
                    <th>Tip dokumenta</th>
                    <th>Datum vazenja</th>
                    <th>
                        <button class="btn btn-danger btn-sm" @click="showAddDocumentDialog()">Dodaj dokument</button>
                    </th>
                </tr>
                </thead>
                <tbody>
                <tr v-for="document in documentList" :key="document.id">
                    <td>{{document.typeName}}</td>
                    <td>{{document.expirationDate}}</td>
                    <td>
                        <div class="btn-group">
                            <button class="btn btn-xs btn-inverse" title="Pregledaj" @click="preview(document.id)"><i class="fa fa-search"></i> </button>
                            <button class="btn btn-xs btn-inverse" title="Preuzmi" @click="download(document.id)"><i class="fa fa-download"></i> </button>
                            <button class="btn btn-xs btn-inverse" title="Obrisi" @click="deleteDocument(document)"><i class="fa fa-trash"></i> </button>
                        </div>
                    </td>
                </tr>
                </tbody>
            </table>
        </widget>

        <a :href="documentUrl" :download="fileName" ref="downloadLink"></a>
    </div>

</template>

<script lang="ts">
    import Vue from 'vue';
    import {Prop, Component, Watch} from 'vue-property-decorator';
    import AddDocumentDialog from '@/components/member-edit/AddDocumentDialog.vue';
    import ModalDialog from '@/components/common/ModalDialog.vue';
    import Widget from "@/components/common/Widget.vue";
    import {DocumentModel, DocumentModel2, DocumentsProxy, MemberModel, MembersProxy} from "@/services/BackendProxies";

    @Component({components: {Widget, AddDocumentDialog, ModalDialog}})
    export default class DocumentsTable extends Vue {
        @Prop({default: () => []}) documents!: any[];
        @Prop() member: MemberModel;

        documentUrl: string = null;
        fileName: string = null;
        documentList: DocumentModel2[] = [];
        previewDocumentUrl = '';
        previewDocumentType = '';

        private membersProxy = new MembersProxy();
        private documentsProxy = new DocumentsProxy();

        @Watch('documents') onDatasourceChanged(documents: any[]) {
            this.documentList = documents;
        }

        showAddDocumentDialog() {
            (<AddDocumentDialog>this.$refs['addDocumentDialog']).show();
        }

        async refreshDocuments() {
            const data = await this.membersProxy.getDocuments(this.member.id);
            this.documentList = data;
        }

        async download(documentId) {
            const data = await this.documentsProxy.getDocument(documentId);
            this.fileName = data.fileName;
            this.documentUrl = data.content;
            this.$nextTick(() => {
                (<any>this.$refs['downloadLink']).click();
            });
        }

        async preview(documentId) {
            const data = await this.documentsProxy.getDocument(documentId);
            this.previewDocumentUrl = `data:${data.contentType};base64,${data.content}`;
            this.$nextTick(() => {
                (<ModalDialog>this.$refs['documentPreview']).open();
            });
        }

        async deleteDocument(document) {
            try {
                const data = await this.membersProxy.deleteDocument(this.member.id, document.id);
                this.documentList = data;
            } catch(err) {
            }
        }
    }
</script>

<style scoped>

</style>