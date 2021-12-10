import {
  Component,
  ContentChild,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChange,
  SimpleChanges,
  TemplateRef,
} from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { IDatatableColumn, SORTORDER } from 'src/models/datatableColumn';
import { DatatableHeader } from 'src/models/datatableHeader';
import { Movie } from 'src/models/movie';
import { PaginationQuery } from 'src/models/paginationQuery';

@Component({
  selector: 'data-table',
  templateUrl: './data-table.component.html',
  styleUrls: [
    '../admin-layout/admin-layout.component.scss',
    './data-table.component.scss',
  ],
})
export class DataTableComponent implements OnChanges, OnInit {
  @ContentChild(TemplateRef) templateRef: TemplateRef<any>;

  @Input() loading: boolean = true;
  @Input() data: any[] = [];
  @Input() columns: IDatatableColumn[] = [];

  @Input() sortable: boolean = false;
  @Input() selectable: boolean = false;
  @Input() clickable: boolean = false;
  @Input() multiple: boolean = false;

  // style
  @Input() minHeight: number = 250;
  @Input() actionsVisible: boolean = false;
  @Input() actionsWidth: number = 90;

  // event
  @Output() loadEvent: EventEmitter<IDatatableLoadEvent> = new EventEmitter();
  @Output() rowClickEvent: EventEmitter<any> = new EventEmitter();
  @Output() selectedRowsChange: EventEmitter<boolean> =
    new EventEmitter<boolean>();
  @Output() sortChangeEvent: EventEmitter<string> = new EventEmitter();

  searchTerm: string = '';
  fromRow: number = 1;
  sortBy: string = 'name';
  sortOrder = SORTORDER.ASCENDING;

  searchBox = {
    isVisible: true,
  };

  selectedRows: any[] = [];

  hasData: boolean = this.data.length === 0;

  @Input('pagination') pagination: PaginationQuery = {
    currentPage: 1,
    pageSize: 5,
    totalPages: 1,
  };
  @Output('onPageChange') onPageChangeEvent =
    new EventEmitter<PaginationQuery>();

  @Input()
  headerTemplate: TemplateRef<any>;

  updateItem: any;
  deleteItem: any;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  ) {}
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    if (this.columns.length !== 0) {
      this.sortBy = this.columns[0].name;
    }
  }
  checkAll(event: any) {
    if (this.selectedRows.length === this.data.length) {
      this.selectedRows = [];
    } else {
      this.selectedRows = Object.assign([], this.data);
    }
  }
  test() {
    this.searchBox.isVisible = false;
  }

  checkRowSelected(row: any){
    return this.selectedRows.some(val => val === row);
  }

  check(row: any) {
    const index: number = this.selectedRows.indexOf(row);
    if (index !== -1) {
      this.selectedRows.splice(index, 1); // Remove row if exist
    } else {
      this.selectedRows.push(row); // Add row to selected rows
    }
  }

  click(event: any): void {
    this.rowClickEvent.emit(event);
  }

  sort(sortEvent: any): void {
    this.selectedRows = [];
    if (this.sortBy !== sortEvent) {
      this.sortBy = sortEvent;
      this.sortOrder = SORTORDER.DESCENDING;
    } else if (this.sortOrder === SORTORDER.ASCENDING) {
      this.sortOrder = SORTORDER.DESCENDING;
    } else {
      this.sortOrder = SORTORDER.ASCENDING;
    }
    this.filter();
  }

  search(searchTerm: string): void {
    this.searchTerm = searchTerm;
    this.filter();
  }

  filter(): void {
    const loadVar: IDatatableLoadEvent = {
      searchTerm: this.searchTerm,
      fromRow: this.fromRow,
      sortBy: this.sortBy,
      sortOrder: this.sortOrder,
    };
    this.loadEvent.emit(loadVar);
  }

  ngOnChanges(changes: SimpleChanges): void {}
  onPageChange(query: PaginationQuery) {
    this.onPageChangeEvent.emit(query);
  }
}
export interface IDatatableLoadEvent {
  searchTerm: string;
  fromRow: number;
  sortBy: string;
  sortOrder: SORTORDER;
}
