import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss']
})
export class NotificationsComponent implements OnInit {

  lst:any[] = []
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  view(id:number){

  }

  add(){
    this.router.navigate(['admin/notification/create']);
  }

}
