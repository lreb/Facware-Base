import { Component, OnDestroy, OnInit } from '@angular/core';
import { ItemsService } from '../../../../core/services/items.service';
import { Item } from '../../../../shared/models/item';
import { CommonModule, NgFor } from '@angular/common';
import { Subscription } from 'rxjs';
import { Store } from '@ngrx/store';
import { addItem } from '../../../../core/store/cart/cart.actions';

@Component({
  selector: 'app-items',
  standalone: true,
  imports: [NgFor, CommonModule],
  templateUrl: './items.component.html',
  styleUrl: './items.component.css'
})
export class ItemsComponent implements OnInit, OnDestroy {
  items: Item[] = [];
  private subscription: Subscription | null = null;

  /**
   *
   */
  constructor(
    private itemsService: ItemsService,
    private store: Store) {
  }

  ngOnInit(): void {
    this.getItems();
  }

  getItems() {
    this.subscription = this.itemsService.getItems().subscribe({//items => {
      next: (items: any) => { // Handle data
        this.items = items.data;
        console.info("data assigned", items.data);
      } ,
      error: (err) => console.error('Error:', err), // Handle error
      complete: () => console.log('Fetch complete') // Handle completion
    });
  }

  addItemToCart(item: Item) {
  console.log('Item added to cart:', item);
    const cartItem: Item = {
      id: item.id,
      name: item.name,
      price: item.price,
      quantity: 1,
    };
    this.store.dispatch(addItem({ item: cartItem }));
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe(); // Clean up
    }
  }
}
