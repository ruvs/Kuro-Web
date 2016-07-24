import { Component }          from '@angular/core';
import { HTTP_PROVIDERS } from '@angular/http';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { ParticipantLibraryService } from './participantLibrary/participantLibrary.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [ParticipantLibraryService,
        HTTP_PROVIDERS]
})

export class AppComponent { }
