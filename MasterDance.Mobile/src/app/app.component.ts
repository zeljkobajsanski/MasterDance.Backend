import { Component } from '@angular/core';

import {ModalController, Platform} from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Device } from '@ionic-native/device/ngx';
import {LoginFailedComponent} from './components/login-failed/login-failed.component';

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
        private device: Device,
        private modalController: ModalController
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
        const uuid = this.device.uuid || '{CF531BC7-5FD1-4012-9E0E-5ABD12F86877}';
        const payload = new HttpParams()
            .set('grant_type', 'password')
            .set('client_id', 'mobileapp')
            .set('username', 'uuid')
            .set('password', uuid);
        this.http.post('http://localhost:5000/connect/token', payload,
            {headers: {'Content-Type': 'application/x-www-form-urlencoded'}}).subscribe(
          token => {
              this.splashScreen.hide();
          },
            async err => {
              const modal = await this.modalController.create({component: LoginFailedComponent, componentProps: {uuid}});
              await modal.present();
            }
        );
    }
}
