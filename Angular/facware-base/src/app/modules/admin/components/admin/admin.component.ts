import { Component } from '@angular/core';
import { ItemsComponent } from '../items/items.component';
import { CartComponent } from '../cart/cart.component';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [ItemsComponent,
    CartComponent
  ],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {

}
