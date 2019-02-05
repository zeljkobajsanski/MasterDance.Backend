import { Component } from '@angular/core';
import {ModalController, ToastController} from '@ionic/angular';
import {SearchComponent} from '../components/search/search.component';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  payment;
  showError = false;

  constructor(private modalController: ModalController, private http: HttpClient, private toastController: ToastController) {
      this.reset();
  }

  async search() {
      const modal = await this.modalController.create({
          component: SearchComponent
      });
      modal.onDidDismiss().then(result => {
          this.payment.member = result.data.member;
      });
      await modal.present();
  }

  reset() {
      this.showError = false;
    this.payment = { date: new Date().toISOString(), amount: '', member: null };
  }

  confirm() {
      if (this.payment.amount <= 0 || !this.payment.member) {
          this.showError = true;
          return;
      }
    this.http.post(`${environment.webapi}/api/mobile/MakePayment`, {
        date: this.payment.date, amount: this.payment.amount, memberId: this.payment.member.id}).subscribe(
        async () => {
            this.reset();
            const toast = await this.toastController.create({
                message: 'Uplata je uspešno obrađena',
                color: 'success',
                position: 'top',
                duration: 2000
            });
            toast.present();
        },
        async err => {
            const toast = await this.toastController.create({
                message: 'Greška prilikom slanja uplate',
                color: 'danger',
                position: 'top',
                showCloseButton: true
            });
            toast.present();
        }

    );
  }
}
