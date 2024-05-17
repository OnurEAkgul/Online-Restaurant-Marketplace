import { ProductInfoModel } from '../../Products/models/ProductInfo.model';

export interface OrderItemInfoModel {
  id: string;
  productId: string;
  quantity: number;
  unitPrice: number;
  orderId: string;
  totalPrice: number;
  productInfo: ProductInfoModel;
}
