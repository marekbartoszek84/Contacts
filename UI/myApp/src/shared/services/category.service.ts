import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentService } from './environment.service';
import { Category } from '../models/category';
import { SubCategoryRequest } from '../models/subCategoryRequest';

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

  public addSubCategory = (route: string, body: SubCategoryRequest) => {
    return this.http.post(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
}
