import * as moment from "moment";

export const convertStringToDateFormat = (date: string) => date ?
    moment(date, 'DD.MM.YYYY').format('YYYY-MM-DD') : null;

export const toFormData = (data: object) => {
    const form = new FormData();
    for(let key in data) {
        form.append(key, data[key]);
    }
    return form;
};