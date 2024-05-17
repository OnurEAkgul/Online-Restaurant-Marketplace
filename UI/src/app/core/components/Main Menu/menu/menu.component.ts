import { Component } from '@angular/core';
import { ShopInfoModel } from 'src/app/core/services/Shops/models/ShopInfo.model';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent {
  restaurants: ShopInfoModel[] = [];
  constructor(private ShopService: ShopsService) {}

  ngOnInit() {
    this.GetRestaurant();
  }

  GetRestaurant() {
    this.ShopService.GetShops().subscribe((data) => {
      if (data) {
        this.restaurants = data.data;
        this.restaurants.slice(0, 12);
        console.log(this.restaurants);
      }
    });
  }
}
