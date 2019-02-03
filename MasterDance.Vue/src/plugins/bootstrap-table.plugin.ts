import 'bootstrap-table/dist/bootstrap-table.min'
import 'bootstrap-table/dist/bootstrap-table.min.css'

declare const $: any;

const update = (el, binding) => {
    $(el).bootstrapTable(binding.value || {});
};

export default {
    install: (Vue) => {
        Vue.directive('table', {
            componentUpdated: update,
        })
    }
}