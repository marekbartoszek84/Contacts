import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserRequest } from '../../shared/models/userRequest';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  standalone: false,
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css',
})
export class AddUserComponent implements OnInit {
  registerForm!: FormGroup;
  errorMessage: string = '';
  showError: boolean = false;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      confirm: new FormControl(''),
    });
  }

  public registerUser = (registerFormValue: any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };
    const user: UserRequest = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
    };
    this.authenticationService
      .registerUser('api/users/add-user', user)
      .subscribe({
        next: (_) => this.router.navigate(['/authentication/login']),
        error: (err: any) => {
          console.error('registration failed');
        },
      });
  };
}
