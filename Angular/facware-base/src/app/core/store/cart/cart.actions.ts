import { createAction, props } from '@ngrx/store';
import { Item } from '../../../shared/models/item';

export const addItem = createAction(
  '[Cart] Add Item',
  props<{ item: Item }>()
);

export const removeItem = createAction(
  '[Cart] Remove Item',
  props<{ id: number }>()
);

export const updateQuantity = createAction(
  '[Cart] Update Quantity',
  props<{ id: number; quantity: number }>()
);

export const clearCart = createAction('[Cart] Clear');
