import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from 'src/models/response';
import { Pagination } from 'src/models/pagination';
import { Actor } from 'src/models/actor';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Param } from 'src/models/param';
@Injectable()
export class ActorService implements BaseService<Actor> {
  baseUrl = `${environment.apiBase}/actors`;
  /**
   *
   */
  constructor(private httpClient: HttpClient) {}
  getAll(param: Param): Observable<Response<Pagination<Actor>>> {
    const params = {
        currentPage: param.currentPage,
        pageSize: param.pageSize
    }
    return this.httpClient.get<Response<Pagination<Actor>>>(this.baseUrl, {params})
  }
  getDetail(id: string | number): Observable<Response<Actor>> {
    return this.httpClient.get<Response<Actor>>(`${this.baseUrl}/${id}`);
  }
  create(body: Actor | FormData): Observable<Response<Actor>> {
    return this.httpClient.post<Response<Actor>>(this.baseUrl, body);
  }
  update(
    id: string | number,
    body: Actor | FormData
  ): Observable<Response<string | number | Actor>> {
    throw new Error('Method not implemented.');
  }
  delete(id: string | number): Observable<Response<string | number>> {
    throw new Error('Method not implemented.');
  }
  // getAll(currentPage: number, pageSize: number): Observable<Response<Pagination<Actor>>>{
  //     var params = {
  //         currentPage: currentPage,
  //         pageSize: pageSize
  //     }
  //     return this.httpClient.get<Response<Pagination<Actor>>>(this.baseUrl, {params});
  // }
}
