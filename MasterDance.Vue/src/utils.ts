import * as numeral from 'numeral'

declare const moment: any;

export const convertStringToDateFormat = (date: string) => date ?
    moment(date, 'DD.MM.YYYY').format('YYYY-MM-DD') : null;

export const formatMoney = (value: number | undefined) => numeral(value || 0).format('0,0.00');