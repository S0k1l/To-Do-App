import { Component, input, output } from '@angular/core';
import { CategoryModel } from '../../interfaces/category-model';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

export interface TaskCreateEvent {
  title: string;
  categoryId: string | null;
  description: string | null;
}

@Component({
  selector: 'app-task-create',
  imports: [ReactiveFormsModule],
  templateUrl: './task-create.html',
  styleUrl: './task-create.css',
})
export class TaskCreate {
  categories = input<CategoryModel[]>([]);
  taskCreated = output<TaskCreateEvent>();

  newTaskForm = new FormGroup({
    newTaskTitle: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
    newTaskDescription: new FormControl<string | null>(null),
    newTaskCategoryId: new FormControl<string | null>(null),
  });

  onSubmit() {
    if (this.newTaskForm.invalid) {
      this.newTaskForm.markAllAsTouched();
      console.log(this.newTaskForm);

      return;
    }

    const { newTaskTitle, newTaskCategoryId, newTaskDescription } = this.newTaskForm.value;

    if (!newTaskTitle) return;

    this.taskCreated.emit({
      title: newTaskTitle.trim(),
      description: newTaskDescription ? newTaskDescription.trim() : null,
      categoryId: newTaskCategoryId!,
    });

    this.newTaskForm.reset();
  }

  get titleControl() {
    return this.newTaskForm.get('newTaskTitle')!;
  }
}
