import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductCategory } from 'src/app/models/products/ProductCategory';
import { ProductService } from 'src/app/services/product.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { environment } from 'src/environments/environment';
import {
  CategoryTypeEnum,
  CategoryTypeToLabel,
} from 'src/app/models/enums/CategoryType';
import { ServiceCategory } from 'src/app/models/services/ServiceCategory';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit {
  productCategories!: ProductCategory[];
  serviceCategories!: ServiceCategory[];
  imgUrl: string = environment.apiUrl + 'File/download/';
  categoryType!: number;

  constructor(
    private router: Router,
    private productService: ProductService,
    private servicesService: ServicesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const categoryType = params.get('categoryType');

      if (categoryType !== null) {
        if (categoryType === CategoryTypeToLabel[CategoryTypeEnum.Product]) {
          this.categoryType = 1;

          this.productService
            .getProductCategories()
            .pipe(take(1))
            .subscribe((cat) => {
              this.productCategories = cat;
            });
        } else {
          this.categoryType = 2;

          this.servicesService
            .getServiceCategories()
            .pipe(take(1))
            .subscribe((cat) => {
              this.serviceCategories = cat;
            });
        }
      } else {
        this.router.navigate([UrlConstants.home]);
      }
    });
  }

  navigate(productCategoryId: number) {
    if (this.categoryType === 1) {
      this.router.navigate([
        UrlConstants.product_types + '/products/' + productCategoryId,
      ]);
    } else {
      this.router.navigate([
        UrlConstants.product_types + '/services/' + productCategoryId,
      ]);
    }
  }
}
