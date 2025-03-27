import { CartState } from "./cart.state";
import { createSelector } from '@ngrx/store';

export const selectCart = (state: { cart: CartState }) => state.cart;

export const selectCartItems = createSelector(
  selectCart,
  (state) => state.items
);

export const selectCartTotal = createSelector(selectCart, (state) => state.total);
