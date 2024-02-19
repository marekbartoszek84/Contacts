import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRequest } from '../models/userRequest';
import { UserResponse } from '../models/userResponse';
import { EnvironmentService } from './environment.service';
import { UserAuthenticationRequest } from '../models/userAuthenticationRequest';
import { UserAuthenticationResponse } from '../models/userAuthenticationResponse';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>();
  public authChanged = this._authChangeSub.asObservable();

  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentService,
    private jwtHelper: JwtHelperService
  ) {}

  public registerUser = (route: string, body: UserRequest) => {
    return this.http.post<UserResponse>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public loginUser = (route: string, body: UserAuthenticationRequest) => {
    return this.http.post<UserAuthenticationResponse>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('token');
    if (token === null) return false;
    else return !this.jwtHelper.isTokenExpired(token);
  };

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
}
