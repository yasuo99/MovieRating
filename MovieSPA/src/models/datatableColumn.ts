export interface IDatatableColumn{
    name: string;
    label: string;
    sortable?: boolean;
    tooltip?: string;
    hidden?: boolean;
    filter?: boolean;
    width?: number;
    noOverflow?: boolean;
    format: DATAFORMAT
}
export interface IDatatableLoadEvent {
    searchTerm: string;
    fromRow: number;
    currentPage: number;
    pageSize: number;
    sortBy: string;
    sortOrder: SORTORDER;
  }
export enum SORTORDER{
    DESCENDING = 1,
    ASCENDING = 2
}
export enum DATAFORMAT{
    KEY = 1,
    TEXT = 2,
    MONEY = 3,
    DATE_TIME = 4,
    IMAGE = 5,
    OBJECT = 6
}