import { createReducer, on } from '@ngrx/store';
import { addItem, removeItem, updateQuantity, clearCart } from './cart.actions';
import { CartState, initialState } from './cart.state';

// The cartReducer function is created using the createReducer function from NgRx.
// It takes the initial state and a series of "on" functions that define how the state should change in response to different actions.
// Each "on" function takes an action and a function that describes how to update the state based on that action.
// The reducer function is responsible for handling the state changes in the cart based on the dispatched actions.

/**
 * Cart reducer function to handle actions related to the cart state.
 * It uses the createReducer function from NgRx to define how the state should change in response to different actions.
 */
const _cartReducer = createReducer(
  initialState,
  // Handle the addItem action
  on(addItem, (state, { item }) => {
    const existingItem = state.items.find((i) => i.id === item.id);
    return {
      ...state,
      items: existingItem
        ? state.items.map((i) =>
            i.id === item.id ? { ...i, quantity: i.quantity + 1 } : i
          )
        : [...state.items, item],
      total: state.total + item.price,
    };
  }),
  // Handle the removeItem action
  on(removeItem, (state, { id }) => ({
    ...state,
    items: state.items.filter((item) => item.id !== id),
    total: state.items.reduce((sum, item) => sum + item.price * item.quantity, 0),
  })),
  // Handle the updateQuantity action
  on(updateQuantity, (state, { id, quantity }) => {
    const itemToUpdate = state.items.find((item) => item.id === id);
    if (!itemToUpdate) return state; // Item not found

    const updatedItem = { ...itemToUpdate, quantity };
    const updatedItems = state.items.map((item) =>
      item.id === id ? updatedItem : item
    );
    const total = updatedItems.reduce(
      (sum, item) => sum + item.price * item.quantity,
      0
    );

    return { ...state, items: updatedItems, total };
  }),
  // Handle the clearCart action
  on(clearCart, () => initialState)
);


/**
 * Cart reducer function to handle actions related to the cart state.
 * It uses the createReducer function from NgRx to define how the state should change in response to different actions.
 * */
export function cartReducer(state: CartState | undefined, action: any) {
  return _cartReducer(state, action);
}
