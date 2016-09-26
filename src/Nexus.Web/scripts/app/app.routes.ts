import { provideRouter, RouterConfig } from '@angular/router';
import { AppComponent } from './app.component';
import { ParticipantLibraryListComponent } from './participantLibrary/ParticipantLibraryList.component';

export const routes: RouterConfig = [
    { path: '', component: AppComponent },
    { path: 'participantLibrary', component: ParticipantLibraryListComponent },
    { path: 'participantLibrary/:id', component: ParticipantLibraryListComponent }
];

export const appRouterProviders = [
    provideRouter(routes)
];


