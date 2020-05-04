import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {IonicModule} from '@ionic/angular';
import {SharedModule} from '../shared/shared.module';
import {RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        IonicModule,
        SharedModule
    ],
    exports: [
        HttpClientModule,
        FormsModule,
        CommonModule,
        RouterModule,
        IonicModule,
    ],
})
export class CoreModule {
}
