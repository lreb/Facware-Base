import { CartState } from "./cart.state";
import { createSelector } from '@ngrx/store';

// This file contains selectors for the cart state in the NgRx store.
// Selectors are functions that allow you to extract specific pieces of state from the store.
export const selectCart = (state: { cart: CartState }) => state.cart;

// Selectors for the cart state
// These selectors are used to get the items in the cart and the total price of the items in the cart.
export const selectCartItems = createSelector(
  selectCart,
  (state) => state.items
);

// Selector to get the total price of items in the cart
// This selector calculates the total price by summing up the price of each item in the cart.
export const selectCartTotal = createSelector(selectCart, (state) => state.total);
