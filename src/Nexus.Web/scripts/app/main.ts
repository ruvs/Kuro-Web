/// <reference path="../../typings/globals/core-js/index.d.ts" />

import { bootstrap }    from '@angular/platform-browser-dynamic';
import { AppComponent } from './app.component';
import { appRouterProviders } from './app.routes';
import { AppConstants } from './helpers/appConstants';

bootstrap(AppComponent, [
    appRouterProviders, AppConstants
])
    .catch(err => console.error(err));
