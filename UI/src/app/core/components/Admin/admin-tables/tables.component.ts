import { Component, OnInit } from '@angular/core';
import { CartItemsService } from 'src/app/core/services/CartItems/cart-items.service';
import { CartItemInfoModel } from 'src/app/core/services/CartItems/models/CartItemInfo.model';
import { CategoriesService } from 'src/app/core/services/Categories/categories.service';
import { CategoryInfoModel } from 'src/app/core/services/Categories/models/CategoryInfo.model';
import { OrderItemsService } from 'src/app/core/services/OrderItems/order-items.service';
import { OrderInfoModel } from 'src/app/core/services/Orders/models/OrderInfo.model';
import { OrdersService } from 'src/app/core/services/Orders/orders.service';
import { ProductInfoModel } from 'src/app/core/services/Products/models/ProductInfo.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShoppingCartModel } from 'src/app/core/services/ShoppingCarts/models/ShoppingCartInfo.model';
import { ShoppingCartsService } from 'src/app/core/services/ShoppingCarts/shopping-carts.service';
import { ShopInfoModel } from 'src/app/core/services/Shops/models/ShopInfo.model';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { TicketInfoModel } from 'src/app/core/services/Tickets/models/TicketInfo.model';
import { TicketsService } from 'src/app/core/services/Tickets/tickets.service';
import { UserInfoModel } from 'src/app/core/services/UserActions/models/UserInfo.model';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css'],
})
export class AdminTablesComponent implements OnInit {
  users: UserInfoModel[] = [];
  tickets: TicketInfoModel[] = [];
  shops: ShopInfoModel[] = [];
  shoppingCart: ShoppingCartModel[] = [];
  products: ProductInfoModel[] = [];
  orders: OrderInfoModel[] = [];
  orderItems: any;
  categories: CategoryInfoModel[] = [];
  cartItems: CartItemInfoModel[] = [];
  constructor(
    private cartItemService: CartItemsService,
    private categoryService: CategoriesService,
    private orderItemService: OrderItemsService,
    private orderService: OrdersService,
    private productService: ProductsService,
    private shoppingCartService: ShoppingCartsService,
    private shopService: ShopsService,
    private ticketService: TicketsService,
    private userService: UserActionsService
  ) {}

  ngOnInit(): void {
    this.GetUserTables();
    this.GetTicketTables();
    this.GetShopTables();
    this.GetProductTables();
    this.GetOrderTables();
    this.GetOrderItemTables();
    this.GetCategoryTables();
    this.GetShoppingCartTables();
    this.GetCartItemTables();
  }

  GetUserTables() {
    this.userService.GetAllUsers().subscribe((response) => {
      this.users = response.data;
    });
  }
  GetTicketTables() {
    this.ticketService.GetAllTickets().subscribe((response) => {
      this.tickets = response.data;
    });
  }
  GetShopTables() {
    this.shopService.GetShops().subscribe((response) => {
      this.shops = response.data;
    });
  }
  GetShoppingCartTables() {
    this.shoppingCartService.GetAllShoppingCarts().subscribe(
      (response) => {
        if (response.data) {
          this.shoppingCart = response.data;
        }
      },
      (error) => {
        this.shoppingCart = error;
      }
    );
  }
  GetCartItemTables() {
    this.cartItemService.GetAllCartItems().subscribe(
      (response) => {
        if (response.data) {
          this.cartItems = response.data;
        }
      },
      (error) => {
        this.cartItems = error;
      }
    );
  }
  GetProductTables() {
    this.productService.GetAllProducts().subscribe((response) => {
      this.products = response.data;
    });
  }
  GetOrderTables() {
    this.orderService.GetAllOrders().subscribe((response) => {
      this.orders = response.data;
    });
  }
  GetOrderItemTables() {
    this.orderItemService.GetAllOrderItems().subscribe((response) => {
      this.orderItems = response;
    });
  }
  GetCategoryTables() {
    this.categoryService.GetAllCategories().subscribe((response) => {
      this.categories = response.data;
    });
  }

  //STATUS UPDATE METHODS
  OrderUpdateStatus(OrderId: string, bool: boolean): void {
    this.orderService
      .UpdateOrderStatus(OrderId, bool)
      .subscribe((response) => {});
  }
  CategoryUpdateStatus(CategoryId: string, bool: boolean): void {
    this.categoryService
      .ToggleCategoryStatus(CategoryId, bool)
      .subscribe((response) => {});
  }
  ProductUpdateStatus(ProductId: string, bool: boolean): void {
    this.productService
      .ToggleProductStatus(ProductId, bool)
      .subscribe((response) => {});
  }
  TicketUpdateStatus(TicketId: string, bool: boolean): void {
    this.ticketService
      .ToggleTicketStatus(TicketId, bool)
      .subscribe((response) => {});
  }
  ShopUpdateStatus(ShopId: string, bool: boolean): void {
    console.log(ShopId);
    console.log(bool);
    this.shopService.OpenCloseShop(ShopId, bool).subscribe((response) => {});
  }
}
