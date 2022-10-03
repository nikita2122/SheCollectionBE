import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from 'src/app/constants';
import { Colour } from 'src/app/models/products/colour';
import { ProductCategory } from 'src/app/models/products/ProductCategory';
import { ProductType } from 'src/app/models/products/ProductType';
import { Size } from 'src/app/models/products/size';
import { ProductService } from 'src/app/services/product.service';
import { take } from 'rxjs/operators';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ProductRequest } from 'src/app/models/products/ProductRequestModel';
import { FileService } from 'src/app/services/file.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
})
export class AddProductComponent implements OnInit {
  loading: boolean = true;
  updating!: boolean;
  sizes: Size[] = [];
  colours: Colour[] = [];
  selectedColours: Colour[] = [];
  categories: ProductCategory[] = [];
  private types: ProductType[] = [];
  filteredTypes: ProductType[] = [];
  addProductForm!: FormGroup;
  file!: File;
  imgUrl!: string | null;

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private fileService: FileService
  ) {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('id');

      this.addProductForm = this.fb.group({
        name: ['', Validators.required],
        desc: ['', Validators.required],
        size: new FormArray([], Validators.required),
        col: new FormArray([], Validators.required),
        cat: [0, Validators.required],
        type: [0, Validators.required],
        price: [0, Validators.required],
        quantity: [0, Validators.required],
      });

      this.productService
        .getProductSizes()
        .pipe(take(1))
        .subscribe((res) => {
          this.sizes = res;

          this.productService
            .getProductColours()
            .pipe(take(1))
            .subscribe((res) => {
              this.colours = res;

              this.productService
                .getProductTypes()
                .pipe(take(1))
                .subscribe((res) => {
                  this.types = res;
                  this.filterTypes(1);

                  this.productService
                    .getProductCategories()
                    .pipe(take(1))
                    .subscribe((res) => {
                      this.categories = res;

                      if (id !== null) {
                        this.updating = true;
                        this.productService
                          .getProductById(+id)
                          .pipe(take(1))
                          .subscribe((prod) => {
                            this.addProductForm.patchValue({
                              name: prod.productName,
                              desc: prod.productDescription,
                              cat: prod.productType.productCategory
                                .productCategoryId,
                              type: prod.productType.productTypeId,
                              price: prod.productPrice,
                              quantity: prod.quantityAvailable,
                            });

                            this.imgUrl =
                              environment.apiUrl +
                              'File/download/' +
                              prod.productPicture;

                            prod.sizes.forEach((size) => {
                              (
                                this.addProductForm.get('size') as FormArray
                              ).push(new FormControl(size.sizeId.toString()));
                            });

                            prod.colours.forEach((col) => {
                              (
                                this.addProductForm.controls['col'] as FormArray
                              ).push(new FormControl(col.colourId.toString()));
                            });

                            this.loading = false;
                          });
                      } else {
                        this.loading = false;
                      }
                    });
                });
            });
        });
    });
  }

  ngOnInit(): void { }

  categoryChange($event: any) {
    this.filterTypes(+$event.target.value);
  }

  filterTypes(categoryId: number) {
    this.filteredTypes = [];
    this.types.forEach((t) => {
      if (t.productCategory.productCategoryId === categoryId)
        this.filteredTypes.push(t);
    });
  }

  onSizeCheckboxChange($event: any, formControlName: string) {
    const selectedSizes = this.addProductForm.controls[
      formControlName
    ] as FormArray;
    if ($event.target.checked) {
      selectedSizes.push(new FormControl(+$event.target.value));
    } else {
      const index = selectedSizes.controls.findIndex(
        (x) => x.value === +$event.target.value
      );
      selectedSizes.removeAt(index);
    }
  }

  shouldBeChecked(value: string, formControlName: string) {
    const val =
      this.addProductForm
        .get(formControlName)
        ?.value.findIndex((x: any) => x === value) !== -1;

    return val;
  }

  addProduct() {
    console.log(this.file);
    this.fileService
      .uploadFile(this.file)
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          console.log(res);

          const fileName = res.fileName;

          const product: ProductRequest = {
            productName: this.addProductForm.get('name')?.value,
            productDescription: this.addProductForm.get('desc')?.value,
            productSizes: this.addProductForm.get('size')?.value,
            productColour: this.addProductForm.get('col')?.value,
            productTypeId: +this.addProductForm.get('type')?.value,
            productCategoryId: +this.addProductForm.get('cat')?.value,
            productPrice: +this.addProductForm.get('price')?.value,
            quantity: +this.addProductForm.get('quantity')?.value,
            productPicture: fileName,
          };

          console.log(product);

          this.productService
            .createProduct(product)
            .pipe(take(1))
            .subscribe({
              next: () => {
                this.router.navigate([UrlConstants.product_management]);
              },
            });
        },
      });
  }

  updateFile($event: any) {
    this.file = $event.target.files[0];

    let reader = new FileReader();

    reader.readAsDataURL(this.file); // read file as data url

    reader.onload = (event: any) => {
      // called once readAsDataURL is complete
      $event.target.parentElement.children[0].src = event.target.result;
    };
  }

  close() {
    this.router.navigate([UrlConstants.product_management]);
  }
}
