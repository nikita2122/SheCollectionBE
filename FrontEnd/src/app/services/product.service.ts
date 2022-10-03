import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/products/product';
import { environment } from 'src/environments/environment';
import { Size } from '../models/products/size';
import { Colour } from '../models/products/colour';
import { ProductCategory } from '../models/products/ProductCategory';
import { ProductType } from '../models/products/ProductType';
import { ProductRequest } from '../models/products/ProductRequestModel';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private productUrl = environment.apiUrl + 'Product/';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl + 'GetAll');
  }

  getProductById(productId: number): Observable<Product> {
    return this.http.get<Product>(this.productUrl + 'GetById', {
      params: new HttpParams().set('id', productId),
    });
  }

  getProductByType(productTypeId: number): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl + 'GetByType', {
      params: new HttpParams().set('id', productTypeId),
    });
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.productUrl + 'Create', {
      product,
    });
  }

  getProductTypesByCategory(categoryId: number): Observable<ProductType[]> {
    return this.http.get<ProductType[]>(
      this.productUrl + 'GetProductTypesByCategory',
      {
        params: new HttpParams().set('categoryId', categoryId),
      }
    );
  }

  deleteProduct(productId: number): Observable<Object> {
    return this.http.delete(this.productUrl + 'Delete', {
      params: new HttpParams().set('id', productId),
    });
  }

  getProductSizes(): Observable<Size[]> {
    return this.http.get<Size[]>(this.productUrl + 'GetProductSizes');
  }

  getProductColours(): Observable<Colour[]> {
    return this.http.get<Colour[]>(this.productUrl + 'GetProductColours');
  }

  getProductCategories(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(
      this.productUrl + 'GetProductCategories'
    );
  }

  getProductTypes(): Observable<ProductType[]> {
    return this.http.get<ProductType[]>(this.productUrl + 'GetProductTypes');
  }

  createProduct(product: ProductRequest) {
    return this.http.post(this.productUrl + 'Create', product);
  }
}
