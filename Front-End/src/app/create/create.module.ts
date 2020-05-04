import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';

import {IonicModule} from '@ionic/angular';
import {CreatePage} from './create.page';
import {SharedModule} from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        IonicModule,
        RouterModule.forChild([
            {
                path: '',
                component: CreatePage
            }
        ])
    ],
    declarations: [CreatePage]
})
export class CreatePageModule {
}
