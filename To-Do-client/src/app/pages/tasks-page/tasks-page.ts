import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { TaskService } from '../../services/task.service';
import { TaskModel } from '../../interfaces/task-model';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoryService } from '../../services/category.service';
import { CategoryModel } from '../../interfaces/category-model';
import { BehaviorSubject, combineLatest, map, Observable, switchMap } from 'rxjs';
import { Sidebar } from '../../components/sidebar/sidebar';
import { TaskSearch } from '../../components/task-search/task-search';
import { TaskCreate } from '../../components/task-create/task-create';
import { Pagination } from '../../components/pagination/pagination';
import { AsyncPipe } from '@angular/common';
import { TaskTable } from '../../components/task-table/task-table';

interface TaskFilter {
  search?: string;
  categoryId?: string;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}

interface TasksViewModel {
  tasks: TaskModel[];
  categories: CategoryModel[];
  filter: TaskFilter;
}

@Component({
  selector: 'app-tasks-page',
  imports: [ReactiveFormsModule, Sidebar, TaskSearch, TaskCreate, Pagination, AsyncPipe, TaskTable],
  templateUrl: './tasks-page.html',
  styleUrl: './tasks-page.css',
})
export class TasksPage {
  private refreshCategories$ = new BehaviorSubject<void>(undefined);

  private filterState$ = new BehaviorSubject<TaskFilter>({
    search: '',
    categoryId: undefined,
    pageNumber: 1,
    pageSize: 10,
    totalPages: 1,
  });

  vm$!: Observable<TasksViewModel>;

  taskService = inject(TaskService);
  categoryService = inject(CategoryService);
  authService = inject(AuthService);

  ngOnInit() {
    const categories$ = this.refreshCategories$.pipe(
      switchMap(() => this.categoryService.getCategories()),
    );

    const tasks$ = this.filterState$.pipe(
      switchMap((currentFilter) => this.taskService.getTasks(currentFilter)),
    );

    this.vm$ = combineLatest([tasks$, categories$, this.filterState$]).pipe(
      map(([tasks, categories, filter]) => ({
        tasks: tasks.items,
        categories,
        filter: {
          ...filter,
          pageNumber: tasks.pageNumber,
          pageSize: tasks.pageSize,
          totalPages: tasks.totalPages,
        },
      })),
    );
  }

  onSearch(query: string) {
    this.updateFilter({ search: query, pageNumber: 1 });
  }

  onCategorySelect(catId: string | undefined) {
    this.updateFilter({ categoryId: catId, pageNumber: 1 });
  }

  onPageChange(newPage: number) {
    this.updateFilter({ pageNumber: newPage });
  }

  private updateFilter(partialFilter: Partial<TaskFilter>) {
    this.filterState$.next({
      ...this.filterState$.value,
      ...partialFilter,
    });
  }

  onCreateTask(title: string, categoryId: string | null, description: string | null) {
    this.taskService.createTask(title, categoryId, description).subscribe(() => {
      this.updateFilter({});
    });
  }

  onUpdateTask(task: TaskModel) {
    this.taskService.updateTask(task).subscribe(() => {
      this.updateFilter({});
    });
  }

  onToggleStatus(taskId: string) {
    this.taskService.toggleComplete(taskId).subscribe(() => {
      this.updateFilter({});
    });
  }

  onDeleteTask(id: string) {
    this.taskService.deleteTask(id).subscribe(() => {
      this.updateFilter({});
    });
  }

  onCreateCategory(name: string, color: string) {
    this.categoryService.createCategory(name, color).subscribe(() => {
      this.refreshCategories$.next();
    });
  }

  onUpdateCategory(category: CategoryModel) {
    this.categoryService.updateCategory(category).subscribe(() => {
      this.refreshCategories$.next();
    });
  }

  onDeleteCategory(id: string) {
    this.categoryService.deleteCategory(id).subscribe(() => {
      this.refreshCategories$.next();
    });
  }

  onLogout() {
    this.authService.logout();
  }
}
