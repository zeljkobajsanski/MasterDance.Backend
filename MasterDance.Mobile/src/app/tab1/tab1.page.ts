import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ToastController} from '@ionic/angular';
import {environment} from '../../environments/environment';

@Component({
    selector: 'app-tab1',
    templateUrl: 'tab1.page.html',
    styleUrls: ['tab1.page.scss']
})
export class Tab1Page {
    get date() {
        return this._date;
    }

    set date(value) {
        this._date = value;
        this.load();
    }

    get group() {
        return this._group;
    }

    set group(value) {
        this._group = value;
        this.load();
    }

    groups = [];
    members = [];

    private _date;
    private _group;


    constructor(private http: HttpClient, private toasts: ToastController) {
        this.date = new Date().toISOString();

        this.http.get<any[]>(`${environment.webapi}/api/mobile/GetMemberGroups`).subscribe(
            data => {
                this.groups = data;
            }
        );
    }

    load() {
        if (this.group) {
            this.http.get<any[]>(`${environment.webapi}/api/mobile/GetEvidence?groupId=${this.group}`).subscribe(
                data => {
                    this.members = data.map(m => ({...m, image: `${m.image ? environment.webapi + m.image : '/assets/img/2.png'}`}));
                }
            );
        }
    }

    confirm() {
        this.http.post<any[]>(`${environment.webapi}/api/mobile/SaveEvidence`, {members: this.members}).subscribe(
            async (data) => {
                const toast = await this.toasts.create({
                    message: 'Podaci su uspešno sačuvani',
                    duration: 2000,
                    position: 'top',
                    color: 'success'});
                toast.present();
                this.load();
            },
            async (err) => {
                const toast = await this.toasts.create({
                    message: 'Greška prilikom snimanja podataka',
                    position: 'top',
                    color: 'danger',
                    showCloseButton: true
                });
                toast.present();
            }
        );
    }

    reset() {
        // this.date = new Date().toISOString();
        this.group = null;
        this.members = [];
    }
}
