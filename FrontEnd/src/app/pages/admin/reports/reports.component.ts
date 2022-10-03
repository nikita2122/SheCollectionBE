import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { take } from 'rxjs/operators';
import { OrderService } from 'src/app/services/order.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { Order } from 'src/app/models/order/order';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/products/product';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss'],
})
export class ReportsComponent implements OnInit {
  @ViewChild('invoice') invoiceElement!: ElementRef;

  showing: number = 0;

  salesData: Order[] = [];
  salesTotal: number = 0;
  date: Date = new Date();
  productData: Product[] = [];

  constructor(
    private orderService: OrderService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {}

  generateInventoryReport() {
    this.showing = 2;
    this.productService
      .getProducts()
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          console.log(res);
          this.productData = res;
        },
      });
  }

  generateSalesReport() {
    this.showing = 1;
    this.orderService
      .getReport(new Date())
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          this.salesData = res;
          res.forEach((x) => {
            this.salesTotal += x.orderTotal;
          });
        },
      });
  }

  downloadPdf() {
    html2canvas(this.invoiceElement.nativeElement, { scale: 3 }).then(
      (canvas) => {
        const imageGeneratedFromTemplate = canvas.toDataURL('image/png');

        const fileWidth = 210;
        const fileHeight = 297;
        const generatedImageHeight = (canvas.height * fileWidth) / canvas.width;
        let PDF = new jsPDF('p', 'mm', 'a4');

        let heightLeft = generatedImageHeight;
        heightLeft -= fileHeight;
        let position = 0;

        PDF.addImage(
          imageGeneratedFromTemplate,
          'PNG',
          0,
          position,
          fileWidth,
          generatedImageHeight
        );

        while (heightLeft >= 0) {
          position = heightLeft - generatedImageHeight;
          PDF.addPage();
          PDF.addImage(
            imageGeneratedFromTemplate,
            'PNG',
            0,
            position,
            fileWidth,
            generatedImageHeight,
            '',
            'FAST'
          );
          heightLeft -= fileHeight;
        }

        PDF.html(this.invoiceElement.nativeElement.innerHTML);
        PDF.save(
          'report-' + this.date.toISOString().replace('/', '-') + '.pdf'
        );
      }
    );
  }
}
