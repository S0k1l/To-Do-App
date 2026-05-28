import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  imports: [],
  templateUrl: './pagination.html',
  styleUrl: './pagination.css',
})
export class Pagination {
  pageNumber = input<number>(1);
  pageSize = input<number>(10);
  totalPages = input<number>(1);

  pageChanged = output<number>();

  onPrevPage() {
    if (this.pageNumber() > 1) {
      this.pageChanged.emit(this.pageNumber() - 1);
    }
  }

  onNextPage() {
    if (this.totalPages > this.pageNumber) {
      this.pageChanged.emit(this.pageNumber() + 1);
    }
  }

  get hasNextPage(): boolean {
    return this.totalPages > this.pageNumber;
  }
}
