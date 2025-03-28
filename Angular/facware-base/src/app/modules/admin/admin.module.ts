import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';

import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { cartReducer } from '../../core/store/cart/cart.reducer';
import { localStorageMetaReducer } from '../../core/store/meta-reducers/local-storage.meta-reducer';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild([
          { path: '', component: AdminComponent }
        ])
  ]
})
export class AdminModule { }
