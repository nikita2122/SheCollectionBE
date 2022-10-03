import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/products/product';
import { ProductService } from 'src/app/services/product.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { environment } from 'src/environments/environment';
import { Service } from 'src/app/models/services/Service';
import {
  CategoryTypeEnum,
  CategoryTypeToLabel,
} from 'src/app/models/enums/CategoryType';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  loading: boolean = true;
  products: Product[] = [];
  services: Service[] = [];
  displayListProd: Product[] = [];
  paginatorNumbers: number[] = [];
  selectedPage: number = 1;
  imgUrl: string = environment.apiUrl + 'File/download/';
  type!: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService,
    private serviceService: ServicesService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const type = params.get('type');

      const id = params.get('productTypeId');

      if (id === null || type === null)
        this.router.navigate([UrlConstants.home]);
      else {
        if (type == CategoryTypeToLabel[CategoryTypeEnum.Product]) {
          this.type = 1;
          this.productService
            .getProductByType(+id)
            .pipe(take(1))
            .subscribe((products) => {
              this.products = products;

              this.paginatorNumbers = Array(
                Math.floor(products.length / 3) +
                  (products.length % 3 > 0 ? 1 : 0)
              )
                .fill(1)
                .map((x, i) => i + 1);

              this.updateList();

              this.loading = false;
            });
        } else {
          this.type = 2;
          this.serviceService
            .getServices(+id)
            .pipe(take(1))
            .subscribe((services) => {
              this.services = services;

              this.loading = false;
            });
        }
      }
    });
  }

  viewProduct(productId: number) {
    this.router.navigate([UrlConstants.view_product_user + '/' + productId]);
  }

  paginatorBeginning() {
    this.selectedPage = 1;
    this.updateList();
  }

  movePaginator(n: number) {
    this.selectedPage = n;
    this.updateList();
  }

  paginatorEnd() {
    this.selectedPage = this.paginatorNumbers.length;
    this.updateList();
  }

  updateList() {
    this.displayListProd = this.products.slice(
      (this.selectedPage - 1) * 3,
      this.selectedPage * 3
    );
  }

  makeABooking() {
    this.router.navigate([UrlConstants.bookings]);
  }
}
