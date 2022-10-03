import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/constants';


@Component({
  selector: 'app-database-backups',
  templateUrl: './database-backups.component.html',
  styleUrls: ['./database-backups.component.scss']
})
export class DatabaseBackupsComponent implements OnInit {

  lst:any[] = []
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  view(id:number){

  }

  add(){
    this.router.navigate(['admin','database','create']);
  }
}
