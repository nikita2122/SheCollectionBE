import { Component, OnInit } from '@angular/core';
import { FileService } from 'src/app/services/file.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  imageNames: string[] = [];

  constructor(private fileService: FileService) {}

  ngOnInit(): void {
    this.fileService
      .getBanners()
      .pipe(take(1))
      .subscribe((res) => {
        this.imageNames = res;
      });
  }
}
