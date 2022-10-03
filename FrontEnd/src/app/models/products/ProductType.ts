import { ProductCategory } from './ProductCategory';

export interface ProductType {
  productTypeId: number;
  productTypeName: string;
  productCategory: ProductCategory;
  imgUrl: string;
}
