import * as numeral from 'numeral'
import moment from 'moment'

export const convertStringToDateFormat = (date: string) => date ?
    moment(date, 'DD.MM.YYYY').format('YYYY-MM-DD') : null;

export const formatMoney = (value: number | undefined) => numeral(value || 0).format('0,0.00');