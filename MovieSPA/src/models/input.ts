export class Column{
    title: string;
    dataProperty: string;
    sortAble: boolean;
    filterAble: boolean;
}
export abstract class RowAction{
    label: string;
    actionIdToReturn: string;
    imageUrl: string;
    abstract action(x: any): any;
}