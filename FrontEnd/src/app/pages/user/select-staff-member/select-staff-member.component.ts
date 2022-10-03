import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { staffMember } from 'src/app/models/user/StaffMember';
import { StaffService } from 'src/app/services/staff.service';

@Component({
  selector: 'app-select-staff-member',
  templateUrl: './select-staff-member.component.html',
  styleUrls: ['./select-staff-member.component.scss'],
})
export class SelectStaffMemberComponent implements OnInit {
  selectedStaffId!: number;
  staffMembers: staffMember[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private staffService: StaffService
  ) {}

  ngOnInit(): void {
    this.staffService
      .getStaffMembers()
      .pipe(take(1))
      .subscribe((res) => {
        this.staffMembers = res;
      });
  }

  navigate() {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const id = params.get('serviceId');

      if (id !== null) {
        this.router.navigate([
          UrlConstants.select_date + '/' + id + '/' + this.selectedStaffId,
        ]);
      } else {
        this.router.navigate([UrlConstants.make_bookings]);
      }
    });
  }

  select(empId: number) {
    this.selectedStaffId = empId;
    Array.from(document.getElementsByClassName('radio')).forEach(
      (element: any) => {
        if (element.id !== 'radio-' + empId) element.checked = false;
      }
    );
  }
}
