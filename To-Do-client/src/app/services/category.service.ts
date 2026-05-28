import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoryModel } from '../interfaces/category-model';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = `${environment.apiBaseUrl}/categories`;

  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<CategoryModel[]>(this.apiUrl);
  }

  createCategory(name: string, color: string) {
    return this.http.post(this.apiUrl, { name, color });
  }

  updateCategory(category: CategoryModel) {
    return this.http.put(`${this.apiUrl}/${category.id}`, { ...category });
  }

  deleteCategory(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
