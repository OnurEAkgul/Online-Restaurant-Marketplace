import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopInfoModel } from 'src/app/core/services/Shops/models/ShopInfo.model';
import { ShopUpdateModel } from 'src/app/core/services/Shops/models/ShopUpdate.model';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-update-shop',
  templateUrl: './update-shop.component.html',
  styleUrls: ['./update-shop.component.css'],
})
export class UpdateShopComponent implements OnInit {
  UpdateModel: ShopUpdateModel;

  // ShopInfo: ShopInfoModel;
  constructor(
    private shopService: ShopsService,
    private userService: UserActionsService,
    private route: ActivatedRoute
  ) {
    this.UpdateModel = {
      contactEmail: '',
      contactPhone: '',
      description: '',
      location: '',
      name: '',
      isOpen: false,
      logoUrl: '',
    };
  }

  ngOnInit() {
    this.getShopId();
    this.GetShopInfo(this.ShopId);
  }

  ShopId: any;
  getShopId() {
    this.route.paramMap.subscribe((response) => {
      this.ShopId = response.get('ShopId');
      console.log(this.ShopId);
    });
  }
  GetShopInfo(ShopId: string) {
    this.shopService.GetShopById(ShopId).subscribe(
      (response) => {
        this.UpdateModel = response.data;
        console.log(response.data);
        console.log(this.UpdateModel);
      },
      (error) => {
        this.UpdateModel = error.data;
      }
    );
  }
  UpdateForm() {
    console.log(this.UpdateModel);
    console.log(this.ShopId);
    this.shopService.UpdateShopInfo(this.ShopId, this.UpdateModel).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
