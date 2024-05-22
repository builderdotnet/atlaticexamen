 
import { AppComponent } from './app/app.component';
import { enableProdMode, importProvidersFrom, isDevMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { environment } from './environments/environment';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import {
    HTTP_INTERCEPTORS,
    HttpClient,
    provideHttpClient,
    withInterceptors,
    withInterceptorsFromDi,
} from '@angular/common/http'; 
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools'; 
import { provideEffects } from '@ngrx/effects'; 

if (environment.production) {
    enableProdMode();
} 
// No Olvidar marcar los componentes como default
bootstrapApplication(AppComponent, {
    providers: [ 
         importProvidersFrom([BrowserAnimationsModule]), 
        provideHttpClient(withInterceptorsFromDi()),
        provideRouter([
            {
                path: '',
                loadComponent: () =>
                    import('./app/bibliotecario/pages/registrarprestamo/registrarprestamo.component'),
            }, 
        ]),  
    ],
}).catch((err) => Error(err));
