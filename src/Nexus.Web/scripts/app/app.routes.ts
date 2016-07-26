import { provideRouter, RouterConfig } from '@angular/router';
import { AppComponent } from './app.component';
import { ParticipantLibraryComponent } from './participantLibrary/participantLibrary.component';

export const routes: RouterConfig = [
    { path: 'participantLibrary', component: ParticipantLibraryComponent },
    { path: 'participantLibrary/:id', component: ParticipantLibraryComponent }
];

export const appRouterProviders = [
    provideRouter(routes)
];


