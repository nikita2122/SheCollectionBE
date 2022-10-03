import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { Colour } from 'src/app/models/products/colour';
import { Size } from 'src/app/models/products/size';
import { ServiceCategory } from 'src/app/models/services/ServiceCategory';
import { ServiceRequest } from 'src/app/models/services/ServiceRequest';
import { ServiceType } from 'src/app/models/services/ServiceTypes';
import { FileService } from 'src/app/services/file.service';
import { ServicesService } from 'src/app/services/services.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-create-promotion',
  templateUrl: './create-promotion.component.html',
  styleUrls: ['./create-promotion.component.scss']
})
export class CreatePromotionComponent implements OnInit {
  loading: boolean = true;
  updating!: boolean;
  sizes: Size[] = [];
  colours: Colour[] = [];
  selectedColours: Colour[] = [];
  categories: ServiceCategory[] = [];
  private types: ServiceType[] = [];
  filteredTypes: ServiceType[] = [];
  addServiceForm!: FormGroup;
  file!: File;
  imgUrl!: string | null;

  constructor(
    private servicesService: ServicesService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private fileService: FileService
  ) {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('id');
      const type = params.get('type');

      this.addServiceForm = this.fb.group({
        name: ['', Validators.required],
        desc: ['', Validators.required],
        cat: [0, Validators.required],
        type: [0, Validators.required],
        price: [0, Validators.required],
        durationMin: [0, Validators.required],
        durationMax: [0, Validators.required],
      });

      this.servicesService
        .getAllServiceTypes()
        .pipe(take(1))
        .subscribe((res) => {
          this.types = res;
          this.filterTypes(1);

          this.servicesService
            .getServiceCategories()
            .pipe(take(1))
            .subscribe((res) => {
              this.categories = res;

              if (id !== null) {
                this.updating = true;
                this.servicesService
                  .getServiceById(+id)
                  .pipe(take(1))
                  .subscribe((ser) => {
                    console.log(ser);
                    this.addServiceForm.patchValue({
                      name: ser.serviceName,
                      desc: ser.serviceDescription,
                      type: ser.serviceType.serviceTypeId,
                      price: ser.servicePrice,
                      durationMin: ser.durationMin,
                      durationMax: ser.durationMax,
                    });

                    this.imgUrl =
                      environment.apiUrl +
                      'File/download/' +
                      ser.servicePicture;

                    this.loading = false;
                  });
              } else {
                this.loading = false;
              }
            });
        });
    });
  }

  ngOnInit(): void {}

  categoryChange($event: any) {
    this.filterTypes(+$event.target.value);
  }

  filterTypes(categoryId: number) {
    this.filteredTypes = [];
    this.types.forEach((t) => {
      if (t.serviceCategory.serviceCategoryId === categoryId)
        this.filteredTypes.push(t);
    });
  }

  addProduct() {
    console.log(this.file);
    this.fileService
      .uploadFile(this.file)
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          const fileName = res.fileName;

          const ser: ServiceRequest = {
            serviceName: this.addServiceForm.get('name')?.value,
            serviceDescription: this.addServiceForm.get('desc')?.value,
            serviceTypeId: +this.addServiceForm.get('type')?.value,
            servicePrice: +this.addServiceForm.get('price')?.value,
            servicePicture: fileName,
            durationMin: +this.addServiceForm.get('durationMin')?.value,
            durationMax: +this.addServiceForm.get('durationMax')?.value,
          };

          this.servicesService
            .createService(ser)
            .pipe(take(1))
            .subscribe({
              next: () => {
                this.router.navigate([UrlConstants.view_services]);
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
    this.router.navigate([UrlConstants.view_services]);
  }
}