import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { IPagination } from "src/models/pagination";
import { ITag, Tag } from "src/models/tag";
import { IResponse } from './../models/response';

@Injectable({
    providedIn: 'any'
})
export class TagServices {
    /**
     *
     */
    private baseUrl = `${environment.apiBase}/tags`
    constructor(private httpClient: HttpClient) {
        
    }
    getAll(currentPage: number, pageSize: number){
        var params = {
            currentPage: currentPage,
            pageSize: pageSize
        }
        return this.httpClient.get<IResponse<IPagination<Tag>>>(this.baseUrl, {params});
    }
    getTag(id: string){
        return this.httpClient.get<IResponse<Tag>>(`${this.baseUrl}/${id}`);
    }
    createTag(data: Tag){
        return this.httpClient.post<IResponse<Tag>>(this.baseUrl, data);
    }
    deleteTag(id: string){
        return this.httpClient.delete<IResponse<any>>(`${this.baseUrl}/${id}`);
    }
}