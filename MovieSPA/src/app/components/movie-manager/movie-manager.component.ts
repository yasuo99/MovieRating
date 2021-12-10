import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/models/movie';
import { MovieService } from 'src/services/movies.services';
import * as myJson from '../../data/movies.json';
import {FormControl, FormGroupDirective, NgForm} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { Pagination } from 'src/models/pagination';
import { Response } from 'src/models/response';
import { PaginationQuery } from 'src/models/paginationQuery';
import { DATAFORMAT, IDatatableColumn } from 'src/models/datatableColumn';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: '[movie-manager]', //Which tag this component can be call in html view
  styleUrls: ['./movie-manager.css', '../admin-layout/admin-layout.component.scss'], //Css file, can be in an array
  templateUrl: './movie-manager.html', //Html file
})
export class MovieManager implements OnInit {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  matcher = new MyErrorStateMatcher();
  data: Movie[] = [];
  detail = new Movie();
  pagination: PaginationQuery = {
    currentPage: 1,
    pageSize: 5,
    totalPages: 1
  };
  fetched = false;


  columns: IDatatableColumn[] = [
    {
      name: 'Id',
      format: DATAFORMAT.KEY,
      label: '',
      hidden: true
    },
    {
      name: 'title',
      label: 'Tieu de',
      format: DATAFORMAT.TEXT,
      sortable: true
    },
    {
      name: 'cover',
      label: 'Anh bia',
      format: DATAFORMAT.IMAGE,
      sortable: false
    },
    {
      name: 'releasedAt',
      label: 'NPH',
      format: DATAFORMAT.DATE_TIME,
      sortable: true
    },
    {
      name: 'pg',
      label: 'PG',
      format: DATAFORMAT.OBJECT,
      sortable: false
    },
    {
      name: 'createAt',
      label: 'Ngay tao',
      format: DATAFORMAT.DATE_TIME
    },
    {
      name: 'modifiedAt',
      label: 'Ngay sua',
      format: DATAFORMAT.DATE_TIME
    }

  ]
  constructor(
    private toastService: ToastrService,
    public movieService: MovieService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.fetchData();
  }
  fetchData() {
    this.movieService
      .getAll(this.pagination.currentPage, this.pagination.pageSize)
      .subscribe((data) => {
        console.log(data);
        this.data = data.data.items;
        this.fetched = true;
        Object.assign(this.pagination, data.data);
      });
  }
  toast(): void {
    this.toastService.success('New success');
  }
  pageChange(event: any) {
    console.log(this.pagination);
    this.pagination.currentPage = event;
    this.fetchData();
  }


  openDetailModal(detailModal: any, data: any){
    this.modalService.open(detailModal);
    this.detail = data;
  }
  submitDelete(data: any){
    console.log(data);
  }
  onPageChange(paginationQuery: PaginationQuery){
    this.pagination.currentPage = paginationQuery.currentPage;
    this.pagination.pageSize = paginationQuery.pageSize;
    this.fetchData();
  }
}
