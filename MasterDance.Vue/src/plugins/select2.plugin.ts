import 'select2';
import 'select2/dist/css/select2.min.css'

declare const $: any;

const updateComponent = (el, binding) => {
    // get options from binding value.
    // v-select="THIS-IS-THE-BINDING-VALUE"
    let options = binding.value || {width: '100%'};

    // set up select2
    $(el).select2(options).on("select2:select", (e) => {
        // v-model looks for
        //  - an event named "change"
        //  - a value with property path "$event.target.value"
        el.dispatchEvent(new Event('change', { target: e.target }));
    });
};

export default {
    install: (Vue, options) => {
        Vue.directive('select2', {
            inserted: updateComponent,
            componentUpdated: updateComponent
        });
    }
}