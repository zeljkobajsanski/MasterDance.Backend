import {EventEmitter, Injectable, Output} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Device} from '@ionic-native/device/ngx';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    accessToken;
    @Output() authenticated = new EventEmitter();

    constructor(private http: HttpClient, private device: Device) { }

    login() {
        return new Promise((resolve, reject) => {
            const uuid = this.device.uuid || '{CF531BC7-5FD1-4012-9E0E-5ABD12F86877}';
            const payload = new HttpParams()
                .set('grant_type', 'password')
                .set('client_id', 'mobileapp')
                .set('username', 'uuid')
                .set('password', uuid);
            this.http.post('http://localhost:5000/connect/token', payload,
                {headers: {'Content-Type': 'application/x-www-form-urlencoded'}}).subscribe(
                token => {
                    this.accessToken = token['access_token'];
                    this.authenticated.emit();
                    resolve();
                },
                async err => {
                    reject(uuid);
                }
            );
        });
    }
}
