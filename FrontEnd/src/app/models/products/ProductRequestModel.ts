export interface ProductRequest {
  productName: string;
  productDescription: string;
  productSizes: number[];
  productColour: number[];
  productTypeId: number;
  productCategoryId: number;
  productPrice: number;
  quantity: number;
  productPicture: string;
}
