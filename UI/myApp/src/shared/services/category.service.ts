import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentService } from './environment.service';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient, private envUrl: EnvironmentService) {}

  public getCategories = (route: string) => {
    return this.http.get<Category[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
}
