import { Colour } from './colour';
import { ProductType } from './ProductType';
import { Size } from './size';

export interface Product {
  productId: number;
  productName: string;
  productDescription: string;
  productBarcode: string;
  quantityAvailable: number;
  productPicture: string;
  productPrice: number;
  productType: ProductType;
  sizes: Size[];
  colours: Colour[];
}
