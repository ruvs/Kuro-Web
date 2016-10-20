import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppConstants } from './shared/appConstants';
import { AppComponent } from './app.component';

/* Feature Modules */
import { ParticipantLibraryModule } from './participantLibrary/participantLibrary.module';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        RouterModule.forRoot([
            { path: 'home', component: AppComponent },
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            //{ path: '**', redirectTo: 'home', pathMatch: 'full' }
        ]),
        ParticipantLibraryModule
    ],
    declarations: [
        AppComponent
        //WelcomeComponent
    ],
    providers: [
        AppConstants
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
