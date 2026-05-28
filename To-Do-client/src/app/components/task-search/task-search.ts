import { Component, DestroyRef, inject, input, output } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-task-search',
  imports: [ReactiveFormsModule],
  templateUrl: './task-search.html',
  styleUrl: './task-search.css',
})
export class TaskSearch {
  initialSearch = input<string | undefined>(undefined);
  searchChanged = output<string>();

  searchControl = new FormControl('');

  private destroyRef = inject(DestroyRef);

  ngOnInit(): void {
    this.searchControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged(), takeUntilDestroyed(this.destroyRef))
      .subscribe((value) => {
        this.searchChanged.emit(value || '');
      });
  }
}
