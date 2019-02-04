import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';

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


    constructor(private http: HttpClient) {
        this.date = new Date().toISOString();

        this.http.get<any[]>('http://localhost:5000/api/mobile/GetMemberGroups').subscribe(
            data => {
                this.groups = data;
            }
        );
    }

    load() {
        if (this.date && this.group) {
            this.http.get<any[]>(`http://localhost:5000/api/mobile/GetMembers?groupId=${this.group}`).subscribe(
                data => this.members = data
            );
        }
    }

    confirm() {
        this.http.post<any[]>(`http://localhost:5000/api/mobile/SaveEvidence`, this.members).subscribe(
            data => {}
        );
    }

    reset() {
        this.date = new Date().toISOString();
        this.group = null;
        this.members = [];
    }
}
