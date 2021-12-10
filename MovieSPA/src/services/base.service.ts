import { Param } from "src/models/param";
import { Observable } from 'rxjs';
import { Pagination } from "src/models/pagination";
import { Response } from 'src/models/response';

export interface BaseService<T>{
    getAll(param: Param): Observable<Response<Pagination<T>>>;
    getDetail(id: number | string): Observable<Response<T>>;
    create(body: FormData | T): Observable<Response<T>>;
    update(id: number | string, body: FormData | T): Observable<Response<T | number | string>>;
    delete(id: number | string): Observable<Response<number | string>>
}