<template>
    <div>
        <ul class="nav nav-tabs">
            <li v-for="(tab, i) in tabs" :key="i" :class="{active: tab.isActive}" @click="selectTab(tab)">
                <a :href="'#tab_' + i" data-toggle="tab">{{tab.title}}</a>
            </li>
        </ul>
        <div class="tab-content">
            <slot></slot>
        </div>
    </div>
</template>

<script lang="ts">
    import {Vue, Component, Prop} from 'vue-property-decorator';
    import Tab from './Tab.vue';

    @Component({components: {}})
    export default class Tabs extends Vue {
        tabs: Tab[] = [];

        created() {
            this.tabs = <Tab[]>this.$children;
        }

        mounted() {
            if (this.tabs && this.tabs.length > 0) {
                this.selectTab(this.tabs[0]);
            }
        }

        selectTab(tab: Tab) {
            for (let i = 0; i < this.tabs.length; i++) {
                this.tabs[i].isActive = false;
            }
            tab.isActive = true;
        }

    }
</script>

<style scoped>

</style>