<template>
    <h2 class="page-title">{{title}}
        <small>{{subtitle}}</small>
    </h2>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator'

    @Component({components: {}})
    export default class PageHeader extends Vue {
        @Prop({default: ''}) title!: string;
        @Prop({default: ''}) subtitle!: string;
    }
</script>

<style scoped>

</style>