import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Product } from 'src/app/models/products/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-promotions',
  templateUrl: './promotions.component.html',
  styleUrls: ['./promotions.component.scss']
})
export class PromotionsComponent implements OnInit {
  products: Product[] = [];
  filteredProducts: Product[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.productService
      .getProducts()
      .pipe(take(1))
      .subscribe((res: Product[]) => {
        this.filteredProducts = this.products = res;
      });
  }

  addProduct() {
    this.router.navigate([UrlConstants.promotions,'admin']);
  }

  viewProduct(productId: number) {
    this.router.navigate([UrlConstants.view_product + '/' + productId]);
  }

  search($event: any) {
    this.filteredProducts = this.products.filter((prod) =>
      prod.productName.toLowerCase().includes($event.toLowerCase())
    );
  }
}

