import { SubCategoryRequest } from './subCategoryRequest';

export interface ContactRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  categoryId: string;
  subCategoryId?: string;
  subCategoryRequest?: SubCategoryRequest;
  phone?: string;
  dateOfBirth: Date;
}
