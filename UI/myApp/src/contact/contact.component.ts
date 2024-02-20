import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/services/contact.service';
import { CategoryService } from '../shared/services/category.service';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../shared/models/contact';

@Component({
  selector: 'app-contact',
  standalone: false,
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css',
})
export class ContactComponent implements OnInit {
  id?: string;
  contact?: Contact;

  constructor(
    private contactService: ContactService,
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (this.id) {
      this.contactService
        .getContact('api/contacts', this.id)
        .subscribe((contact) => {
          this.contact = contact;
        });
    }
  }
}
