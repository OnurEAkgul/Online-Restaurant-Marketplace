import { Component, OnInit } from '@angular/core';
import { CartItemsService } from 'src/app/core/services/CartItems/cart-items.service';
import { CategoriesService } from 'src/app/core/services/Categories/categories.service';
import { OrderItemsService } from 'src/app/core/services/OrderItems/order-items.service';
import { OrdersService } from 'src/app/core/services/Orders/orders.service';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShoppingCartsService } from 'src/app/core/services/ShoppingCarts/shopping-carts.service';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { TicketsService } from 'src/app/core/services/Tickets/tickets.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css'],
})
export class AdminTablesComponent implements OnInit {
  users: any;
  tickets: any;
  shops: any;
  shoppingCart: any;
  products: any;
  orders: any;
  orderItems: any;
  categories: any;
  cartItems: any;

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
    this.GetShoppingCartTables();
    this.GetProductTables();
    this.GetOrderTables();
    this.GetOrderItemTables();
    this.GetCategoryTables();
    this.GetCartItemTables();
  }

  GetUserTables() {
    this.userService.GetAllUsers().subscribe((response) => {
      this.users = response;
    });
  }
  GetTicketTables() {
    this.ticketService.GetAllTickets().subscribe((response) => {
      this.tickets = response;
    });
  }
  GetShopTables() {
    this.shopService.GetShops().subscribe((response) => {
      this.shops = response;
    });
  }
  GetShoppingCartTables() {
    this.shoppingCartService.GetAllShoppingCarts().subscribe(
      (response) => {
        if (response.data) {
          this.shoppingCart = response;
        }
      },
      (error) => {}
    );
  }
  GetProductTables() {
    this.productService.GetAllProducts().subscribe((response) => {
      this.products = response;
    });
  }
  GetOrderTables() {
    this.orderService.GetAllOrders().subscribe((response) => {
      this.orders = response;
    });
  }
  GetOrderItemTables() {
    this.orderItemService.GetAllOrderItems().subscribe((response) => {
      this.orderItems = response;
    });
  }
  GetCategoryTables() {
    this.categoryService.GetAllCategories().subscribe((response) => {
      this.categories = response;
    });
  }
  GetCartItemTables() {
    this.cartItemService.GetAllCartItems().subscribe(
      (response) => {
        if (response.data) {
          this.cartItems = response;
        }
      },
      (error) => {}
    );
  }
}
