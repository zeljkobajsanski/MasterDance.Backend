import { Component } from '@angular/core';

import {ModalController, Platform} from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Device } from '@ionic-native/device/ngx';
import {LoginFailedComponent} from './components/login-failed/login-failed.component';
import {AuthService} from './services/auth.service';

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
        private modalController: ModalController,
        private authService: AuthService
    ) {
        this.initializeApp();
    }

    initializeApp() {
        this.platform.ready().then(() => {
            this.statusBar.styleDefault();
            setTimeout(() => this.login(), 500);
        });
    }

    login() {
        this.authService.login().then(() => {
            this.splashScreen.hide();
        }).catch(async (uuid) => {
            const modal = await this.modalController.create({component: LoginFailedComponent, componentProps: {uuid}});
            await modal.present();
        });
    }
}
