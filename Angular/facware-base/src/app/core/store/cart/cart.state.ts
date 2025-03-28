import { Item } from "../../../shared/models/item";

// This file defines the initial state of the cart in the application.
// It includes the structure of the cart state and the initial values for the items and total price.
export interface CartState {
  items: Item[];
  total: number;
}

// The initial state of the cart is defined here. It starts with an empty array of items and a total price of 0.
// This state will be used by the NgRx store to manage the cart's state throughout the application.
export const initialState: CartState = {
  items: [],
  total: 0,
};
