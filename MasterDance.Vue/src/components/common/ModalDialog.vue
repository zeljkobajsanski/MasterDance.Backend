<template>
    <div class="modal fade" tabindex="-1" role="dialog" ref="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">{{title}}</h4>
                </div>
                <div class="modal-body">
                    <slot></slot>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Zatvori</button>
                    <button type="button" class="btn btn-primary" @click="accept()">Prihvati</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
</template>

<script lang="ts">
    import {Vue, Component, Prop, Emit, Watch} from 'vue-property-decorator'

    declare const $: any;

    @Component({components: {}})
    export default class ModalDialog extends Vue {
        @Prop({default: ''}) title!: string;

        open() {
            const ref = $(<any>this.$refs['dialog']);
            ref.modal({show: true});
        }

        close() {
            const ref = $(<any>this.$refs['dialog']);
            ref.modal('hide');
        }

        @Emit('accepted') accept() {}
    }
</script>

<style scoped>

</style>