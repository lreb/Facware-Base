import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/internal/Observable';
import { Item } from '../../../../shared/models/item';
import { CartState } from '../../../../core/store/cart/cart.state';
import { clearCart, removeItem,updateQuantity } from '../../../../core/store/cart/cart.actions';
import { selectCartItems, selectCartTotal } from '../../../../core/store/cart/cart.selectors';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  items$: Observable<Item[]>;
  total$: Observable<number>;

  constructor(private store: Store<{ cart: CartState }>) {
    // this.items$ = this.store.select((state) => state.cart.items);
    // this.total$ = this.store.select((state) => state.cart.total);
    // with ngrx selector
    this.items$ = this.store.select(selectCartItems);
    this.total$ = this.store.select(selectCartTotal);
  }

  remove(id: number) {
    this.store.dispatch(removeItem({ id }));
  }

  removeOne(item: Item) {
    this.store.dispatch(updateQuantity({ id: item.id, quantity: item.quantity - 1 }));
  }

  addOne(item: Item) {
    this.store.dispatch(updateQuantity({ id: item.id, quantity: item.quantity + 1 }));
  }

  clearCart() {
    this.store.dispatch(clearCart()); // Assuming you have a way to clear the cart
  }
}
