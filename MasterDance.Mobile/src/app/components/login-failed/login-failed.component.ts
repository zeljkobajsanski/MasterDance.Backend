import {Component, Input, OnInit} from '@angular/core';
import {ModalController, ToastController} from '@ionic/angular';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-login-failed',
  templateUrl: './login-failed.component.html',
  styleUrls: ['./login-failed.component.scss']
})
export class LoginFailedComponent implements OnInit {

  @Input() uuid;
  constructor(private modalController: ModalController, private http: HttpClient, private toasts: ToastController) { }

  ngOnInit() {
  }

  register() {
      this.http.post(`${environment.webapi}/api/mobile/registerDevice`, {deviceId: this.uuid}).subscribe(
          async () => {
              const toast = await this.toasts.create({
                  message: 'Uspešna registracija Vašeg uređaja. Nalog će biti uskoro aktiviran.',
                  position: 'bottom',
                  color: 'success',
                  showCloseButton: true
              });
              toast.present();
          },
        async err => {
            const toast = await this.toasts.create({
                message: 'Neuspešna registracija uređaja. Pokušajte ponovo...',
                position: 'bottom',
                color: 'danger',
                duration: 2000
            });
            toast.present();
        }
      );
  }

  login() {
      const payload = new HttpParams()
          .set('grant_type', 'password')
          .set('client_id', 'mobileapp')
          .set('username', 'uuid')
          .set('password', this.uuid);
      this.http.post('http://localhost:5000/connect/token', payload,
          {headers: {'Content-Type': 'application/x-www-form-urlencoded'}}).subscribe(
          (token) => {
              this.modalController.dismiss();
           },
          async err => {
             const toast = await this.toasts.create({
                 message: 'Neuspešna prijava na sistem. Pokušajte ponovo...',
                 position: 'bottom',
                 color: 'danger',
                 duration: 2000
             });
             toast.present();
          }
      );
  }
}
