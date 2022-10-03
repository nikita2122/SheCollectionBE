import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Product } from 'src/app/models/products/product';
import { AppState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { CartService } from 'src/app/services/cart.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-product-user',
  templateUrl: './view-product-user.component.html',
  styleUrls: ['./view-product-user.component.scss'],
})
export class ViewProductUserComponent implements OnInit {
  loading: boolean = true;
  product!: Product;
  imgUrl: string = environment.apiUrl + 'File/download/';

  productForm!: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private store: Store<AppState>,
    private cartService: CartService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('productId');

      if (id !== null) {
        this.productService
          .getProductById(+id)
          .pipe(take(1))
          .subscribe((prod) => {
            this.product = prod;
            this.loading = false;

            this.productForm = this.fb.group({
              quantity: [1, Validators.required],
              colour: [prod.colours[0].colourId, Validators.required],
              size: [prod.sizes[0].sizeId, Validators.required],
            });
          });
      } else {
        this.router.navigate([UrlConstants.categories]);
      }
    });
  }

  addToCart() {
    this.store
      .select('AuthStore')
      .pipe(take(1))
      .subscribe((store) => {
        if (store !== undefined)
          this.cartService
            .addToCart(
              this.product.productId,
              this.productForm.get('colour')?.value,
              this.productForm.get('colour')?.value,
              this.productForm.get('size')?.value,
              store.userId
            )
            .pipe(take(1))
            .subscribe({
              next: () => {
                this.router.navigate([UrlConstants.cart]);
              },
            });
      });
  }

  cancel() {
    this.router.navigate([
      UrlConstants.products + '/' + this.product.productType.productTypeId,
    ]);
  }
}
