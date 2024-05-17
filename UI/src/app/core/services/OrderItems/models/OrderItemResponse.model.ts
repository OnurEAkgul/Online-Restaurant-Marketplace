export interface OrderItemResponseModel {
  orderItem: OrderItemResponseModel;
  orderItems: OrderItemResponseModel[];
  totalOrderPrice: number;
  message: string;
  successful: boolean;
}
