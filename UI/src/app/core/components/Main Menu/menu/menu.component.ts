import { Component } from '@angular/core';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent {
  restaurants: any;
  constructor(private ShopService: ShopsService) {}

  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant() {
    this.ShopService.GetShops().subscribe((data) => {
      if (data) {
        this.restaurants = data;
        this.restaurants.data.slice(0, 12);
        console.log(this.restaurants);
      }
    });
  }
  getSeverity(restaurant: any) {
    switch (restaurant.inventoryStatus) {
      case 'INSTOCK':
        return 'success';

      case 'LOWSTOCK':
        return 'warning';

      case 'OUTOFSTOCK':
        return 'danger';

      default:
        return null;
    }
  }
}
