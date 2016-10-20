import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { IParticipantLibraryItem } from './participantLibraryItem';
import { IParticipantLibraryItemType } from './participantLibraryItemType';
import { AppConstants } from '../shared/appConstants';

@Injectable()
export class ParticipantLibraryService {
    private _participantLibraryItems;
    private _participantLibraryItemTypes;
    private _participantLibraryItemsByType;
    
    constructor(private _http: Http,
        private _appConstants: AppConstants) {
        this._participantLibraryItemTypes = _appConstants.BASE_URL +        'api/participantLibrary/participants/types';
        this._participantLibraryItems = _appConstants.BASE_URL +            'api/participantLibrary/participants';
        this._participantLibraryItemsByType = _appConstants.BASE_URL +      'api/participantLibrary/participants/byType/';
    }

    getParticipantLibraryItems(): Observable<IParticipantLibraryItem[]> {
        return this._http.get(this._participantLibraryItems)
            .map((response: Response) => <IParticipantLibraryItem[]>response.json())
            //.do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getParticipantLibraryItemTypes(): Observable<IParticipantLibraryItemType[]> {
        return this._http.get(this._participantLibraryItemTypes)
            .map((response: Response) => <IParticipantLibraryItemType[]>response.json())
            //.do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getParticipantLibraryItemsByType(typeKey: string): Observable<IParticipantLibraryItem[]> {
        return this._http.get(this._participantLibraryItemsByType + typeKey)
            .map((response: Response) => <IParticipantLibraryItem[]>response.json())
            //.do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
} 