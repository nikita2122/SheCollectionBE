import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmailService } from 'src/app/services/email.service';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';

@Component({
  selector: 'app-forgot-psswd',
  templateUrl: './forgot-psswd.component.html',
  styleUrls: ['./forgot-psswd.component.scss'],
})
export class ForgotPsswdComponent implements OnInit {
  loading: boolean = false;
  email!: string;
  errMsg!: string;

  constructor(private emailService: EmailService, private router: Router) {}

  ngOnInit(): void {}

  update() {
    if (this.email !== undefined)
      this.emailService
        .sendForgotPasswordEmail(this.email)
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.router.navigate([UrlConstants.login]);
          },
          error: () => {
            this.errMsg = 'Email not found';
          },
        });
  }
}
