import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'filter'
})
export class FilterPipe implements PipeTransform {
    transform(value: any, ...args: any[]): any {
        if (args.length === 2) {
            const text = args[0].toLowerCase();
            const group = args[1];
            if (text) {
                value = value.filter(x => x.firstName.toLowerCase().indexOf(text) > -1 || x.lastName.toLowerCase().indexOf(text) > -1);
            }
            if (group) {
                value = value.filter(x => x.memberGroupId == group);
            }
        }
        return value;
    }
}
