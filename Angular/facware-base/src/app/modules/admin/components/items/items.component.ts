import { Component, OnDestroy, OnInit } from '@angular/core';
import { ItemsService } from '../../../../core/services/items.service';
import { Item } from '../../../../shared/models/item';
import { NgFor } from '@angular/common';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-items',
  standalone: true,
  imports: [NgFor],
  templateUrl: './items.component.html',
  styleUrl: './items.component.css'
})
export class ItemsComponent implements OnInit, OnDestroy {
  items: Item[] = [];
  private subscription: Subscription | null = null;

  /**
   *
   */
  constructor(private itemsService: ItemsService) {
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

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe(); // Clean up
    }
  }
}
