import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClient, HttpClientModule} from '@angular/common/http';
import { Device } from '@ionic-native/device/ngx';
import { SearchComponent } from './components/search/search.component';
import {FilterPipe} from './components/search/filter.pipe';
import {FormsModule} from '@angular/forms';
import { LoginFailedComponent } from './components/login-failed/login-failed.component';
import {AuthService} from './services/auth.service';
import {AuthInterceptorService} from './services/auth-interceptor.service';

@NgModule({
  declarations: [AppComponent, SearchComponent, FilterPipe, LoginFailedComponent],
  entryComponents: [SearchComponent, LoginFailedComponent],
  imports: [BrowserModule, IonicModule.forRoot(), AppRoutingModule, HttpClientModule, FormsModule],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
      Device, AuthService,
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
