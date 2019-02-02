<template>
    <div class="tab-pane fade" :class="{active: isActive, in: isActive}">
        <slot></slot>
    </div>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator'
    import Tabs from './Tabs.vue';

    @Component({components: {}})
    export default class Tab extends Vue {
        @Prop() title: string;
        @Prop({default: false}) isActive;
    }
</script>

<style scoped>

</style>