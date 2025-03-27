import { createReducer, on } from '@ngrx/store';
import { addItem, removeItem, updateQuantity, clearCart } from './cart.actions';
import { CartState, initialState } from './cart.state';

const _cartReducer = createReducer(
  initialState,
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
  on(removeItem, (state, { id }) => ({
    ...state,
    items: state.items.filter((item) => item.id !== id),
    total: state.items.reduce((sum, item) => sum + item.price * item.quantity, 0),
  })),
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
  on(clearCart, () => initialState)
);

export function cartReducer(state: CartState | undefined, action: any) {
  return _cartReducer(state, action);
}
