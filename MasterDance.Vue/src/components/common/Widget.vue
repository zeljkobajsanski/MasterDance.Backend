<template>
    <section class="widget">
        <header>
            <h4>
                {{title}}
                <small>
                    {{subtitle}}
                </small>
            </h4>
            <div class="widget-controls" v-if="showToolbar">
                <a title="Options" href="#"><i class="glyphicon glyphicon-cog"></i></a>
                <a data-widgster="expand" title="Expand" href="#"><i
                        class="glyphicon glyphicon-chevron-up"></i></a>
                <a data-widgster="collapse" title="Collapse" href="#"><i
                        class="glyphicon glyphicon-chevron-down"></i></a>
                <a data-widgster="close" title="Close" href="#"><i
                        class="glyphicon glyphicon-remove"></i></a>
            </div>
            <div class="actions">
                <slot name="actions"></slot>
            </div>
        </header>
        <div class="body">
            <slot></slot>
        </div>
    </section>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator'

    @Component({components: {}})
    export default class Widget extends Vue {
        @Prop({default: ''}) title!: string;
        @Prop({default: ''}) subtitle!: string;
        @Prop({default: false}) showToolbar!: boolean;
    }
</script>

<style scoped>
    .widget {
        min-height: 28px;
    }
</style>