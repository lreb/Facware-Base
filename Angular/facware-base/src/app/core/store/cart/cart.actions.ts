import { createAction, props } from '@ngrx/store';
import { Item } from '../../../shared/models/item';

// This file contains actions for the cart state in the NgRx store.
// Actions are payloads of information that send data from your application to the store.
// They are the only source of information for the store and are dispatched to trigger state changes.

/**
 * Action to add an item to the cart.
 * The action type is '[Cart] Add Item' and it carries the item to be added as a payload.
 */
export const addItem = createAction(
  '[Cart] Add Item',
  props<{ item: Item }>()
);

/**
 * Action to remove an item from the cart.
 * The action type is '[Cart] Remove Item' and it carries the id of the item to be removed as a payload.
 */
export const removeItem = createAction(
  '[Cart] Remove Item',
  props<{ id: number }>()
);

/**
 * Action to update the quantity of an item in the cart.
 * The action type is '[Cart] Update Quantity' and it carries the id of the item and the new quantity as payload.
 */
export const updateQuantity = createAction(
  '[Cart] Update Quantity',
  props<{ id: number; quantity: number }>()
);

/**
 * Action to clear the cart.
 * The action type is '[Cart] Clear' and it does not carry any payload.
 */
export const clearCart = createAction('[Cart] Clear');
