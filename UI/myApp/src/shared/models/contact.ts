import { Category } from './category';

export interface Contact {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  caategory: Category;
  phone: string;
  dateOfBirth: Date;
}
