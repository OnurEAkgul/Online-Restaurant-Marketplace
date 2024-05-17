export interface ProductCreateModel {
  name: string;
  price: number;
  description: string;
  categoryId: string;
  imageUrl: string;
  isActive: boolean;
  shopId: string;
}
