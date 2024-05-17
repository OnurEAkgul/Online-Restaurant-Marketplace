export interface OrderInfoModel {
  id: string;
  shopId: string;
  shopName: string;
  orderDate: Date;
  totalAmount: null;
  isCompleted: boolean;
  customerUserId: string;
}
