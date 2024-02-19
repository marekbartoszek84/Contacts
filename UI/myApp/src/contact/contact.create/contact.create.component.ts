import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ContactService } from '../../shared/services/contact.service';
import { ContactRequest } from '../../shared/models/contactRequest';
import { Router } from '@angular/router';
import { Category } from '../../shared/models/category';
import { CategoryService } from '../../shared/services/category.service';

@Component({
  selector: 'app-contact.create',
  standalone: false,
  templateUrl: './contact.create.component.html',
  styleUrl: './contact.create.component.css',
})
export class ContactCreateComponent implements OnInit {
  contactForm!: FormGroup;
  public categories: Category[] = [];

  constructor(
    private contactService: ContactService,
    private categoryService: CategoryService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.contactForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      phone: new FormControl(''),
      category: new FormControl(''),
      dateOfBirth: new FormControl(''),
    });

    this.getCategories();
  }

  public addContact = (contactFormValue: any) => {
    const formValues = { ...contactFormValue };
    const contact: ContactRequest = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      phone: formValues.phone,
      categoryId: formValues.category,
      dateOfBirth: formValues.dateOfBirth,
    };

    this.contactService.addContact('api/contacts', contact).subscribe({
      next: (_) => this.router.navigate(['/contacts']),
      error: (err: any) => {
        console.error('adding failed');
      },
    });
  };

  getCategories = () => {
    const apiAddress: string = 'api/categories';
    this.categoryService.getCategories(apiAddress).subscribe({
      next: (cat: Category[]) => (this.categories = cat),
      error: (err: any) => console.error('error during list getting'),
    });
  };
}
