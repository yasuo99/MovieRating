import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IPagination } from 'src/models/pagination';
import { PaginationQuery } from 'src/models/paginationQuery';
import { IResponse } from 'src/models/response';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent implements OnInit {
  @Input('configuration') configuration: any;
  @Output('onPageChange') pageChange = new EventEmitter<PaginationQuery>();
  @Input('pagination') pagination: PaginationQuery = {
    currentPage: 1,
    pageSize: 5,
    totalPages: 5
  };
  sizes = [5, 10, 15, 20];
  constructor() {}

  ngOnInit(): void {
    if (this.pagination.pageSize) {
      this.pagination.pageSize = this.pagination.pageSize;
    }
  }
  onPageChange(page: number) {
    this.pagination.currentPage = page;
    this.pageChange.emit(this.pagination);
  }
  onSizeChange(size: any) {
    this.pagination.pageSize = size.value;
    this.pageChange.emit(this.pagination);
  }
}
