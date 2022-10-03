import { Colour } from '../products/colour';
import { Product } from '../products/product';
import { Size } from '../products/size';

export interface OrderLine {
  orderQuantity: number;
  product: Product;
  colour: Colour;
  size: Size;
}
