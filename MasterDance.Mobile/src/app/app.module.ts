import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { Device } from '@ionic-native/device/ngx';
import { SearchComponent } from './components/search/search.component';
import {FilterPipe} from './components/search/filter.pipe';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [AppComponent, SearchComponent, FilterPipe],
  entryComponents: [SearchComponent],
  imports: [BrowserModule, IonicModule.forRoot(), AppRoutingModule, HttpClientModule, FormsModule],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
      Device
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
