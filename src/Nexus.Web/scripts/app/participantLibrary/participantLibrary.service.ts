import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

import { IParticipantLibraryItem } from './participantLibraryItem';

@Injectable()
export class ParticipantLibraryService {
    //private _participantLibraryItems = 'https://jsonplaceholder.typicode.com/todos';
    private _participantLibraryItems = 'http://localhost:5793/api/participantLibrary/participants';

    constructor(private _http: Http) { }

    getParticipantLibraryItems(): Observable<IParticipantLibraryItem[]> {
        return this._http.get(this._participantLibraryItems)
            .map((response: Response) => <IParticipantLibraryItem[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
} 