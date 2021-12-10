import { DATAFORMAT, IDatatableColumn } from 'src/models/datatableColumn';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DataTableType } from 'src/models/dataTableType';
import { IPagination } from 'src/models/pagination';
import { IResponse } from 'src/models/response';
import { Tag } from 'src/models/tag';
import { TagServices } from 'src/services/tags.services';

@Component({
  selector: 'app-tag-manager',
  templateUrl: './tag-manager.component.html',
  styleUrls: ['./tag-manager.component.scss', '../admin-layout/admin-layout.component.scss']
})
export class TagManagerComponent implements OnInit {
  data: any
  pagintation = {
    currentPage: 1,
    pageSize: 5
  }
  createForm = this.formBuilder.group({
    tagName: ['', Validators.required]
  });
  tableConfig: DataTableType = {
    columns: [
      {title: "First Name", dataProperty: "firstName", sortAble: true, filterAble: false},
      {title: "Last Name", dataProperty: "lastName", sortAble: true, filterAble: true},
      {title: "Occupation", dataProperty: "occupation", sortAble: false, filterAble: false},
      {title: "Branch", dataProperty: "companyBranch", sortAble: false, filterAble: true},
    ],
    rowActions: [
      {label: "Edit", actionIdToReturn: "edit", imageUrl: "...", action: (x) => true },
      {label: "Copy", actionIdToReturn: "copy", imageUrl: "...", action: (x) => {console.log('dkm')} },
      {label: "Delete", actionIdToReturn: "delete", imageUrl: "...", action: (x) => !x.isActive },
      {label: "Message", actionIdToReturn: "message", imageUrl: "...", action: (x) => x.permitsMessaging },
    ],
  }

  tableColumns: IDatatableColumn[] = [
    {
      name: 'username',
      label: 'Username',
      format: DATAFORMAT.KEY
    },
    {
      name: 'fullname',
      label: 'Fullname',
      format: DATAFORMAT.TEXT
    },
    {
      name: 'address',
      label: 'address',
      format: DATAFORMAT.TEXT
    },
    
  ]
  
  testData = [
    {
      username: 'thanh',
      fullname: 'luyen ngoc thanh',
      address: '484 le van viet'
    },
    {
      username: 'thanh 1',
      fullname: 'luyen ngoc thanh',
      address: '484 le van viet'
    },
    {
      username: 'thanh 2',
      fullname: 'luyen ngoc thanh',
      address: '484 le van viet'
    },
    {
      username: 'thanh 3',
      fullname: 'luyen ngoc thanh',
      address: '484 le van viet'
    },
    {
      username: 'thanh 3',
      fullname: 'luyen ngoc thanh',
      address: '484 le van viet'
    },
  ]

  keys = Object.keys(new Tag());
  constructor(private toastService: ToastrService,public tagService: TagServices, private modalService: NgbModal, private formBuilder: FormBuilder) { }
  fetchData(){
    this.tagService.getAll(this.pagintation.currentPage,this.pagintation.pageSize).subscribe((data) => {
      this.data = data;
    })
  }
  ngOnInit(): void {
    this.fetchData();
    console.log("dkmm");
    console.log(this.tableConfig.rowActions[1].label)
    this.tableConfig.rowActions[1].action(1);
  }
  submitCreate(modal: any){
    this.tagService.createTag(this.createForm.value).subscribe((result) => {
      if(result.statusCode === 200){
        this.toastService.success("Thanh cong");
        this.createForm.reset();
        modal.close()
        this.fetchData();
      }else{
        this.toastService.error("That bai")
      }
    });
  }
  openCreateModal(modal: any){
    this.modalService.open(modal);
  }
  openEditModal(modal: any, data: any){
    this.modalService.open(modal)
  }
  openDeleteModal(modal: any, data: any){
    this.modalService.open(modal);
  }
  submitDelete(data: any){
    console.log(data);
    this.tagService.deleteTag(data.id).subscribe((result) => {
      if(result.statusCode == 200){
        this.toastService.success("Deleted")
        this.fetchData();

      }else{
        this.toastService.error("Error");
      }
    });
    
  }
  onPageChange(newData: any){
    this.data = newData;
  }
}
