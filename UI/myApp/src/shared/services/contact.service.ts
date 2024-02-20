import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentService } from './environment.service';
import { Contact } from '../models/contact';
import { ContactRequest } from '../models/contactRequest';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private http: HttpClient, private envUrl: EnvironmentService) {}

  public getContact = (route: string, id: string) => {
    return this.http.get<Contact>(
      this.createCompleteRoute(route, this.envUrl.urlAddress) + '/' + id
    );
  };

  public getContacts = (route: string) => {
    return this.http.get<Contact[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };

  public addContact = (route: string, body: ContactRequest) => {
    return this.http.post(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public updateContact = (route: string, body: Contact) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public deleteContact = (route: string, id: string) => {
    return this.http.delete(
      this.createCompleteRoute(route, this.envUrl.urlAddress) + '/' + id
    );
  };

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
}
