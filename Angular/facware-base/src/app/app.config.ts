import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { provideStore, StoreModule } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideEffects } from '@ngrx/effects';
import { cartReducer } from './core/store/cart/cart.reducer';
import { localStorageMetaReducer } from './core/store/meta-reducers/local-storage.meta-reducer';

import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideStore(
      { cart: cartReducer },
      { metaReducers: [localStorageMetaReducer] }
    ), // register ngrx store
    provideEffects([]), // Add root effects here if needed
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() }) // Enable Redux DevTools
  ]
};
