import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.scss'],
})
export class BannerComponent implements OnInit {
  @Input() data: any[] = [];
  imgUrl: string = environment.apiUrl + 'File/download/banner/';
  selectedIndex: number = 0;

  constructor() {}

  ngOnInit(): void {}

  changeIndex(i: number) {
    this.selectedIndex = i;
  }

  incIndex() {
    if (this.selectedIndex === this.data.length - 1) this.selectedIndex = 0;
    else this.selectedIndex++;
  }
  decIndex() {
    if (this.selectedIndex === 0) this.selectedIndex = this.data.length - 1;
    else this.selectedIndex--;
  }
}
