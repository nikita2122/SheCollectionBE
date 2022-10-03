import { Colour } from '../products/colour';
import { Product } from '../products/product';
import { Size } from '../products/size';
import { Cart } from './cart';

export interface CartLine {
  cartLineId: number;
  cartQuantity: number;
  cart: Cart;
  product: Product;
  colour: Colour;
  size: Size;
}
