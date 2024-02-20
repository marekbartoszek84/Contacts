import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ContactService } from '../../shared/services/contact.service';
import { ContactRequest } from '../../shared/models/contactRequest';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../shared/models/category';
import { CategoryService } from '../../shared/services/category.service';
import { SubCategory } from '../../shared/models/subcategory';
import { Contact } from '../../shared/models/contact';

@Component({
  selector: 'app-contact.create',
  standalone: false,
  templateUrl: './contact.create.component.html',
  styleUrl: './contact.create.component.css',
})
export class ContactCreateComponent implements OnInit {
  contactForm!: FormGroup;
  id?: string;
  isAddMode?: boolean;
  public categories: Category[] = [];
  public subCategories: SubCategory[] = [];

  constructor(
    private contactService: ContactService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.contactForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      phone: new FormControl(''),
      categoryId: new FormControl(''),
      subCategoryId: new FormControl(''),
      dateOfBirth: new FormControl(''),
    });

    this.contactForm.get('categoryId')?.valueChanges.subscribe((val) => {
      this.subCategories =
        this.categories.find((ca) => ca.id == val)?.subCategories ?? [];
    });

    this.getCategories();

    if (!this.isAddMode && this.id) {
      this.contactService
        .getContact('api/contacts', this.id)
        .subscribe((x) => this.contactForm.patchValue(x));
    }
  }

  public onSubmit = (contactFormValue: any) => {
    if (this.contactForm.invalid) {
      return;
    }

    if (this.isAddMode) {
      this.addContact(contactFormValue);
    } else {
      this.updateContact(contactFormValue);
    }
  };

  public addContact = (contactFormValue: any) => {
    const formValues = { ...contactFormValue };
    const contact: ContactRequest = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      phone: formValues.phone,
      categoryId: formValues.categoryId,
      subCategoryId: formValues.subCategoryId,
      dateOfBirth: formValues.dateOfBirth,
    };

    this.contactService.addContact('api/contacts', contact).subscribe({
      next: (_) => this.router.navigate(['/contacts']),
      error: (err: any) => {
        console.error('adding failed');
      },
    });
  };

  public updateContact = (contactFormValue: any) => {
    if (this.id) {
      const formValues = { ...contactFormValue };
      const contact: Contact = {
        id: this.id,
        firstName: formValues.firstName,
        lastName: formValues.lastName,
        email: formValues.email,
        password: formValues.password,
        phone: formValues.phone,
        categoryId: formValues.categoryId,
        subCategoryId: formValues.subCategoryId,
        dateOfBirth: formValues.dateOfBirth,
      };

      this.contactService.updateContact('api/contacts', contact).subscribe({
        next: (_) => this.router.navigate(['/contacts']),
        error: (err: any) => {
          console.error('adding failed');
        },
      });
    }
  };

  getCategories = () => {
    const apiAddress: string = 'api/categories';
    this.categoryService.getCategories(apiAddress).subscribe({
      next: (cat: Category[]) => (this.categories = cat),
      error: (err: any) => console.error('error during list getting'),
    });
  };
}
