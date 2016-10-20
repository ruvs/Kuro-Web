import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ParticipantLibraryListComponent } from './participantLibraryList.component';
import { ParticipantLibraryItemsByTypeComponent } from './participantLibraryItemsByType.component';

import { ParticipantLibraryService } from './participantLibrary.service';

import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
            //{ path: '', redirectTo: 'participantLibrary' },
            { path: 'participantLibrary', component: ParticipantLibraryListComponent },
            { path: 'participantLibrary/:id', component: ParticipantLibraryListComponent }
            //{
            //    path: 'product/:id',
            //    canActivate: [ProductDetailGuard],
            //    component: ProductDetailComponent
            //}
        ])
    ],
    declarations: [
        ParticipantLibraryListComponent,
        ParticipantLibraryItemsByTypeComponent
    ],
    providers: [
        ParticipantLibraryService
    ]
})

export class ParticipantLibraryModule { }