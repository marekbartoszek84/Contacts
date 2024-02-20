import { Component, OnInit } from '@angular/core';
import { Contact } from '../../shared/models/contact';
import { ContactService } from '../../shared/services/contact.service';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts',
  standalone: false,
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css',
})
export class ContactsComponent implements OnInit {
  public contacts: Contact[] = [];

  constructor(
    private contactService: ContactService,
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts = () => {
    const apiAddress: string = 'api/contacts/GetAll';
    this.contactService.getContacts(apiAddress).subscribe({
      next: (com: Contact[]) => (this.contacts = com),
      error: (err: any) => console.error('error during list get'),
    });
  };

  deleteContact = (id: string) => {
    const apiAddress: string = 'api/contacts';
    this.contactService
      .deleteContact(apiAddress, id)
      .subscribe(() => this.getContacts());
  };

  editContact = (id: string) => {
    this.router.navigate(['/contact/edit/' + id]);
  };

  detailsContact = (id: string) => {
    this.router.navigate(['/contact/' + id]);
  };

  public isUserAuthenticated = () => {
    return this.authenticationService.isUserAuthenticated();
  };
}
