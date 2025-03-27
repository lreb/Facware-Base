import { Item } from "../../../shared/models/item";

export interface CartState {
  items: Item[];
  total: number;
}

export const initialState: CartState = {
  items: [],
  total: 0,
};
