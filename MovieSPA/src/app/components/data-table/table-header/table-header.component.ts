import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IDatatableColumn, SORTORDER } from "src/models/datatableColumn";

@Component({
    selector: '[table-header]',
    templateUrl: './table-header.component.html',
    styleUrls: [
        '../../admin-layout/admin-layout.component.scss',
        './table-header.component.css'
    ]
})
export class TableHeader{
    
    @Input() activeClass: string = 'active';
    @Input() sortBy: string = 'name';

    @Input() sortAble: boolean = !this.sortBy;
    @Input() sortOrder: SORTORDER
    
    @Input() label: string;
    @Input() columns: IDatatableColumn[] = []

    @Output() sortChangeEvent: EventEmitter<any> = new EventEmitter();

    @Output() checkAllEvent: EventEmitter<any> = new EventEmitter();

    @Input() selectedRowsCount: number = 0;
    @Input() dataRowsCount: number = 0;


    onSortChange(event: any){
        this.sortChangeEvent.emit(event)
    }

    checkAll(){
        this.checkAllEvent.emit();
    }
}