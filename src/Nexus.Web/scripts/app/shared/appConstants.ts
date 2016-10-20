import { Injectable } from '@angular/core';

@Injectable()
export class AppConstants {
    BASE_URL: string;

    constructor() {
        this.BASE_URL = 'http://localhost:5793/'
    }
}
