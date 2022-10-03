import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/products/product';
import { ProductService } from 'src/app/services/product.service';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/constants';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.scss'],
})
export class ProductManagementComponent implements OnInit {
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
    this.router.navigate([UrlConstants.add_product]);
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
