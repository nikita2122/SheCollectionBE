import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-reset-passwd',
  templateUrl: './reset-passwd.component.html',
  styleUrls: ['./reset-passwd.component.scss'],
})
export class ResetPasswdComponent implements OnInit {
  errMsg!: string;
  loading: boolean = true;
  password!: string;
  passwordConf!: string;
  private email!: string;
  private code!: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(take(1)).subscribe((params) => {
      const email = params.get('email');
      const code = params.get('code');

      if (email !== null && code !== null) {
        this.email = email;
        this.code = code;
      } else [this.router.navigate([UrlConstants.login])];

      this.loading = false;
    });
  }

  update() {
    if (this.password === this.passwordConf)
      this.authService
        .resetPassword(this.email, this.password, this.code)
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.router.navigate([UrlConstants.login]);
          },
          error: () => {
            this.errMsg = 'Something went wrong';
          },
        });
    else this.errMsg = 'Passwords must match';
  }
}
