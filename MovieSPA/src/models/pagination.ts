
export interface IPagination<T> {
  totalPages: number;
  currentPage: number;
  pageSize: number;
  items: T[];
}
export class Pagination<T> implements IPagination<T>{
  totalPages: number;
  currentPage: number;
  pageSize: number;
  items: T[];
  /**
   *
   */
  constructor(totalPages: number, currentPage: number, pageSize: number, items: T[]) {
    this.totalPages = totalPages;
    this.currentPage = currentPage;
    this.pageSize = pageSize;
    this.items = items;
  }
}