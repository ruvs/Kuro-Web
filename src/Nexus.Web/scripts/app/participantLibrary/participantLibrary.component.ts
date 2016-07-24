import { Component, OnInit } from '@angular/core';
import { Router, ROUTER_DIRECTIVES } from '@angular/router';

import { IParticipantLibraryItem } from './participantLibraryItem';
import { ParticipantLibraryService } from './participantLibrary.service';

@Component({
    selector: 'mytest',
    templateUrl: 'app/participantLibrary/participantLibrary.component.html',
    directives: [ROUTER_DIRECTIVES]
})
export class ParticipantLibraryComponent implements OnInit {
    pageTitle: string = 'Participant Library List';
    errorMessage: string;
    participantLibraryItems: IParticipantLibraryItem[];

    constructor(private router: Router,
        private _participantLibraryService: ParticipantLibraryService) {

    }
     
    ngOnInit(): void {
        this._participantLibraryService.getParticipantLibraryItems()
            .subscribe(
            pli => this.participantLibraryItems = pli,
            error => this.errorMessage = <any>error);
    }
}
