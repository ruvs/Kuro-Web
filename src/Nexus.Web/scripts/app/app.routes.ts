import { provideRouter, RouterConfig } from '@angular/router';
import { AppComponent } from './app.component';
import { ParticipantLibraryComponent } from './participantLibrary/participant-library.component';

export const routes: RouterConfig = [
    { path: 'home', component: AppComponent },
    { path: 'participant-library', component: ParticipantLibraryComponent },
    { path: 'participant-library/:id', component: ParticipantLibraryComponent }
];

export const appRouterProviders = [
    provideRouter(routes)
];


