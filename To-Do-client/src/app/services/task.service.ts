import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TaskModel } from '../interfaces/task-model';
import { PaginationResult } from '../interfaces/pagination-result';
import { environment } from '../../environments/environment.development';

interface TaskFilterParams {
  search?: string;
  categoryId?: string | null;
  pageNumber?: number;
  pageSize?: number;
  totalPages: number;
}

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private apiUrl = `${environment.apiBaseUrl}/tasks`;

  constructor(private http: HttpClient) {}

  getTasks(filters: TaskFilterParams) {
    let params = new HttpParams();

    if (filters.search && filters.search.trim() !== '') {
      params = params.set('search', filters.search.trim());
    }

    if (filters.categoryId) {
      params = params.set('categoryId', filters.categoryId.toString());
    }

    if (filters.pageNumber) {
      params = params.set('pageNumber', filters.pageNumber.toString());
    }

    if (filters.pageSize) {
      params = params.set('pageSize', filters.pageSize.toString());
    }

    return this.http.get<PaginationResult<TaskModel>>(this.apiUrl, { params });
  }

  createTask(title: string, categoryId: string | null, description: string | null) {
    return this.http.post(this.apiUrl, { title, categoryId, description });
  }

  updateTask(task: TaskModel) {
    return this.http.put(`${this.apiUrl}/${task.id}`, { ...task });
  }

  toggleComplete(id: string) {
    return this.http.patch(`${this.apiUrl}/${id}/toggle-complete`, {});
  }

  deleteTask(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
