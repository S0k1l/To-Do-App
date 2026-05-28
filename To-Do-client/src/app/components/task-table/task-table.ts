import { Component, input, output, signal } from '@angular/core';
import { TaskModel } from '../../interfaces/task-model';
import { CategoryModel } from '../../interfaces/category-model';

@Component({
  selector: 'app-task-table',
  imports: [],
  templateUrl: './task-table.html',
  styleUrl: './task-table.css',
})
export class TaskTable {
  tasks = input<TaskModel[]>();
  categories = input<CategoryModel[]>([]);

  taskUpdated = output<TaskModel>();
  toggleStatus = output<string>();
  delete = output<string>();

  tableHead = signal<string[]>(['Name', 'Description', 'Category']);
  editingTaskId = signal<string | null>(null);
  editTitle = signal<string>('');
  editDescription = signal<string>('');
  editCategoryId = signal<string | null>(null);

  onToggleStatus(id: string) {
    this.toggleStatus.emit(id);
  }

  onDelete(id: string) {
    this.delete.emit(id);
  }

  startEdit(task: any) {
    this.editingTaskId.set(task.id);
    this.editTitle.set(task.title);
    this.editDescription.set(task.description || '');
    this.editCategoryId.set(task.categoryId || null);

    console.log({
      id: task.id,
      title: task.title,
      description: task.description,
      categoryId: task.categoryId,
      isCompleted: task?.isCompleted!,
    });
  }

  cancelEdit() {
    this.editingTaskId.set(null);
  }

  saveEdit(taskId: string) {
    const task = this.tasks()?.find((t) => t.id === taskId);

    if (!this.editTitle().trim()) this.editTitle.set(task?.title!);

    this.taskUpdated.emit({
      id: taskId,
      title: this.editTitle().trim(),
      description: this.editDescription().trim(),
      categoryId: this.editCategoryId() === 'null' ? null : this.editCategoryId(),
      isCompleted: task?.isCompleted!,
    });

    this.editingTaskId.set(null);
  }

  getCategoryColor(id: string | null | undefined) {
    const category = this.categories().find((c) => c.id === id);
    return category ? category.color : '#fff';
  }
}
