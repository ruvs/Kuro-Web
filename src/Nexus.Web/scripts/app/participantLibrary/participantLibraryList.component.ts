import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { IParticipantLibraryItem } from './participantLibraryItem';
import { IParticipantLibraryItemType } from './participantLibraryItemType';
import { ParticipantLibraryService } from './participantLibrary.service';

@Component({
    selector: 'participantLibraryList',
    templateUrl: 'app/participantLibrary/participantLibraryList.component.html',
})
export class ParticipantLibraryListComponent implements OnInit {
    pageTitle: string = 'Participant Library List';
    errorMessage: string;
    participantLibraryItemTypes: IParticipantLibraryItemType[];

    constructor(private router: Router,
        private _participantLibraryService: ParticipantLibraryService) {

    }

    //getParticipantsByType(typeKey: string) {
    //    this._participantLibraryService.getParticipantLibraryItemsByType(typeKey)
    //        .subscribe(
    //        pli => this.participantLibraryItems = pli,
    //        error => this.errorMessage = <any>error);
    //}

    //getAllParticipants() {
    //    return this._participantLibraryService.getParticipantLibraryItems()
    //        .subscribe(
    //        pli => this.participantLibraryItems = pli,
    //        error => this.errorMessage = <any>error);
    //}

    ngOnInit(): void {
        this._participantLibraryService.getParticipantLibraryItemTypes()
            .subscribe(
            plit => this.participantLibraryItemTypes = plit,
            error => this.errorMessage = <any>error);
    }
}
