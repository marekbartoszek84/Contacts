import { Category } from './category';
import { SubCategory } from './subcategory';

export interface Contact {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  categoryId: string;
  caategory?: Category;
  subCategoryId: string;
  subCategory?: SubCategory;
  phone: string;
  dateOfBirth: Date;
}
