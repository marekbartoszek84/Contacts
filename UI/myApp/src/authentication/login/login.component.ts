import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserAuthenticationRequest } from '../../shared/models/userAuthenticationRequest';
import { UserAuthenticationResponse } from '../../shared/models/userAuthenticationResponse';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  private returnUrl: string = '';

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  errorMessage: string = '';

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  loginUser = (loginFormValue: any) => {
    const login = { ...loginFormValue };

    const userForAuth: UserAuthenticationRequest = {
      email: login.username,
      password: login.password,
    };

    this.authService.loginUser('api/users/login', userForAuth).subscribe({
      next: (res: UserAuthenticationResponse) => {
        localStorage.setItem('token', res.token);
        this.router.navigate([this.returnUrl]);
      },
      error: (err: any) => {
        console.error('Login failed');
      },
    });
  };
}
