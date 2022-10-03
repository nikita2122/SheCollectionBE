import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-notification',
  templateUrl: './create-notification.component.html',
  styleUrls: ['./create-notification.component.scss']
})
export class CreateNotificationComponent implements OnInit {
  ngOnInit(): void {
   
  }


  close(){

  }

  add(name:HTMLInputElement,subject:HTMLInputElement,email:HTMLInputElement,desc:HTMLTextAreaElement){

  }
}
