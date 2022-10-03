import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Product } from 'src/app/models/products/product';
import { ProductService } from 'src/app/services/product.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.scss'],
})
export class ViewProductComponent implements OnInit {
  loading: boolean = true;
  product!: Product;
  imgUrl: string = environment.apiUrl + 'File/download/';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('id');

      if (id !== null) {
        this.productService
          .getProductById(+id)
          .pipe(take(1))
          .subscribe((res) => {
            this.product = res;
            this.loading = false;
          });
      } else {
        this.router.navigate([UrlConstants.product_management]);
      }
    });
  }

  close() {
    this.router.navigate([UrlConstants.product_management]);
  }

  deleteProd() {
    this.productService
      .deleteProduct(this.product.productId)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.close();
        },
      });
  }

  updateProd() {
    this.router.navigate([
      UrlConstants.update_product + '/' + this.product.productId,
    ]);
  }
}
