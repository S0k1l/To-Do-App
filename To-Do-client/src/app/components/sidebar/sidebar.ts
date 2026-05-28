import { Component, input, output, signal } from '@angular/core';
import { CategoryModel } from '../../interfaces/category-model';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-sidebar',
  imports: [ReactiveFormsModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  categories = input<CategoryModel[]>();
  selectedCategory = input<string | undefined>(undefined);
  categorySelected = output<string | undefined>();
  logoutRequested = output();
  categoryCreated = output<{ name: string; color: string }>();
  categoryDelete = output<string>();
  categoryUpdate = output<CategoryModel>();

  categoryId = signal<string | undefined>(undefined);

  categoryForm = new FormGroup({
    name: new FormControl('', { validators: [Validators.required], nonNullable: true }),
    color: new FormControl('#432dd7'),
  });

  editCategory(id: string) {
    const category = this.categories()?.find((c) => c.id == id);
    if (!category) return;
    this.categoryId.set(category.id);
    this.categoryForm.patchValue({ name: category.name, color: category.color });
  }

  cancelEdit() {
    this.categoryId.set(undefined);
    this.categoryForm.reset({
      name: '',
      color: '#432dd7',
    });
  }

  onUpdateCategory() {
    if (this.categoryForm.invalid) {
      this.categoryForm.markAllAsTouched();
      return;
    }

    const id = this.categoryId()!.trim();
    const { name, color } = this.categoryForm.value;

    if (!name || !color || !id) return;

    this.categoryUpdate.emit({ id, name, color });

    this.cancelEdit();
  }

  onCreateCategory() {
    if (this.categoryForm.invalid) {
      this.categoryForm.markAllAsTouched();
      return;
    }

    const { name, color } = this.categoryForm.value;

    if (!name || !color) return;

    this.categoryCreated.emit({ name, color });

    this.categoryForm.reset({
      name: '',
      color: '#432dd7',
    });
  }

  onDeleteCategory(id: string) {
    this.categoryDelete.emit(id);
  }

  selectCategory(id: string | undefined) {
    this.categorySelected.emit(id);
  }

  onLogout() {
    this.logoutRequested.emit();
  }

  get isEditMode() {
    return this.categoryId();
  }

  get nameControl() {
    return this.categoryForm.get('name')!;
  }
}
