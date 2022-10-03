import { Component, OnInit } from '@angular/core';
import { UrlConstants } from 'src/app/constants';
import { take } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { ProductType } from 'src/app/models/products/ProductType';
import { environment } from 'src/environments/environment';
import {
  CategoryTypeEnum,
  CategoryTypeToLabel,
} from 'src/app/models/enums/CategoryType';
import { ServiceType } from 'src/app/models/services/ServiceTypes';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-product-types',
  templateUrl: './product-types.component.html',
  styleUrls: ['./product-types.component.scss'],
})
export class ProductTypesComponent implements OnInit {
  productTypes!: ProductType[];
  serviceTypes!: ServiceType[];
  imgUrl: string = environment.apiUrl + 'File/download/';
  type!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private serviceService: ServicesService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const type = params.get('type');
      const id = params.get('categoryId');
      if (id !== null && type !== null) {
        if (type == CategoryTypeToLabel[CategoryTypeEnum.Product]) {
          this.type = 1;
          this.productService
            .getProductTypesByCategory(+id)
            .pipe(take(1))
            .subscribe((types) => {
              this.productTypes = types;
            });
        } else {
          this.type = 2;
          this.serviceService
            .getServiceTypes(+id)
            .pipe(take(1))
            .subscribe((types) => {
              this.serviceTypes = types;
            });
        }
      } else {
        this.router.navigate([UrlConstants.categories]);
      }
    });
  }

  navigate(productTypeId: number) {
    if (this.type === 1)
      this.router.navigate([
        UrlConstants.products + '/products/' + productTypeId,
      ]);
    else
      this.router.navigate([
        UrlConstants.products + '/services/' + productTypeId,
      ]);
  }
}
