<template>
    <div class="modal fade" tabindex="-1" role="dialog" ref="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Slika</h4>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2"></label>
                            <div class="col-sm-9">
                                <div>
                                    <img :src="image" ref="image" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2 form-label-left">Datoteka</label>
                            <div class="col-sm-9">
                                <input type="file" class="form-control" @change="onImageSelected($event)" accept="image/*">
                            </div>
                        </div>
                    </form>
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
    import {Vue, Component, Prop, Watch, Emit} from 'vue-property-decorator';
    import Cropper from 'cropperjs';

    declare const $: any;

    @Component({components: {}})
    export default class ImageEditModal extends Vue {
        @Prop() value: string;
        cropper: Cropper;
        image: string;

        @Watch('value')
        onValueChanged(newValue: string) {
            this.image = newValue || '/img/2.png';
        }

        @Emit('input') applyCrop(data: string) {}

        mounted() {
            const el = <HTMLImageElement>this.$refs['image'];
            this.cropper = new Cropper(el, {aspectRatio: 1});
        }

        show()  {
            $(this.$refs['dialog']).modal({show: true});
        }

        onImageSelected(event: Event) {
            const files: FileList = event.target['files'];
            if (files.length === 1) {
                const reader = new FileReader();
                reader.onload = (e: ProgressEvent) => {
                    const result: string = <string>e.target['result'];
                    this.cropper.reset();
                    this.cropper.replace(result);


                };
                reader.readAsDataURL(files[0]);
            }
        }

        accept() {
            const canvas = this.cropper.getCroppedCanvas();
            if (canvas) {
                this.applyCrop(canvas.toDataURL());
            }
            $(this.$refs['dialog']).modal('hide');
        }
    }
</script>

<style scoped>
    @import "~cropperjs/dist/cropper.min.css";
    img {
        width: 240px;
        height: 240px;
    }
</style>