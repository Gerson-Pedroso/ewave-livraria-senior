import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {RouteReuseStrategy} from '@angular/router';
import {HTTP_INTERCEPTORS} from '@angular/common/http';

import {IonicModule, IonicRouteStrategy} from '@ionic/angular';
import {SplashScreen} from '@ionic-native/splash-screen/ngx';
import {StatusBar} from '@ionic-native/status-bar/ngx';

import {AppComponent} from './app.component';
import {AppRoutingModule} from './app-routing.module';
import {CoreModule} from './core/core.module';
import {InterceptedHttp} from './core/intercepted-http.service';
import {environment} from '../environments/environment';

import { AngularFireModule } from '@angular/fire';
import { AngularFireStorageModule } from '@angular/fire/storage';
import {AngularFirestoreModule} from '@angular/fire/firestore';

@NgModule({
    declarations: [AppComponent],
    entryComponents: [],
    imports: [
        CoreModule,
        BrowserModule,
        AngularFireStorageModule,
        AngularFirestoreModule,
        AngularFireModule.initializeApp(environment.firebase),
        IonicModule.forRoot(),
        AppRoutingModule
    ],
    providers: [
        StatusBar,
        SplashScreen,
        {provide: HTTP_INTERCEPTORS, useClass: InterceptedHttp, multi: true},
        {provide: RouteReuseStrategy, useClass: IonicRouteStrategy}

    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
