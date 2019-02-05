import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ModalController} from '@ionic/angular';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  members = [];
  groups = [];
  private _searchText = '';
  private _selectedGroup = null;

  constructor(private httpClient: HttpClient, private modalController: ModalController) { }


    get searchText(): string {
        return this._searchText;
    }

    set searchText(value: string) {
        this._searchText = value;
    }

    get selectedGroup(): any {
        return this._selectedGroup;
    }

    set selectedGroup(value: any) {
        this._selectedGroup = value;
    }

    ngOnInit() {
      this.load();
    }

    load() {
        this.httpClient.get<any[]>(`${environment.webapi}/api/mobile/GetMembers`).subscribe(
            data => {
                this.members = data.map(m => ({...m, image: m.image ? environment.webapi + m.image : '/assets/img/2.png'}));
            }
        );
        this.httpClient.get<any[]>(`${environment.webapi}/api/mobile/GetMemberGroups`).subscribe(
            data => {
                this.groups = data;
            }
        );
    }

    select(member) {
      this.modalController.dismiss({member});
    }

    filter() {

    }

}
