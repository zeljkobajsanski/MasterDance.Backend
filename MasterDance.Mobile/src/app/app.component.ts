import { Component } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Device } from '@ionic-native/device/ngx';

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html'
})
export class AppComponent {
    constructor(
        private platform: Platform,
        private splashScreen: SplashScreen,
        private statusBar: StatusBar,
        private http: HttpClient,
        private device: Device
    ) {
        this.initializeApp();
    }

    initializeApp() {
        this.platform.ready().then(() => {
            this.statusBar.styleDefault();

        });
        this.login();
    }

    login() {
        const payload = new HttpParams()
            .set('grant_type', 'password')
            .set('client_id', 'mobileapp')
            .set('username', 'uuid')
            .set('password', this.device.uuid);
        this.http.post('http://localhost:5000/connect/token', payload,
            {headers: {'Content-Type': 'application/x-www-form-urlencoded'}}).subscribe(
          token => {
            console.log(token);
              this.splashScreen.hide();
          },
            err => {
              console.error(err);
            }
        );
    }
}
