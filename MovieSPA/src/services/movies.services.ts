import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { IPagination } from "src/models/pagination";
import { IResponse } from "src/models/response";
import {Movie} from '../models/movie';

interface IMovieService{
    getAll(currentPage: number, pageSize: number): Observable<IResponse<IPagination<Movie>>>;
    GetMovie(id: string): Observable<IResponse<Movie>>;
    createMovie(movie: object): Observable<IResponse<string>>;
    UpdateMovie(id: string, movie: FormData): IResponse<Movie>;
    DeleteMovie(id: string): IResponse<Movie>;

}
@Injectable({
    providedIn: 'root'
})
export class MovieService implements IMovieService{
    /**
     *
     */
    private baseUrl: string = `${environment.apiBase}/movies`
    constructor(private httpClient: HttpClient) {
    }
getAll(currentPage: number, pageSize: number): Observable<IResponse<IPagination<Movie>>> {
        var params = {
            currentPage: currentPage,
            pageSize: pageSize
        };
        var result = this.httpClient.get<IResponse<IPagination<Movie>>>(this.baseUrl, {params});
        return result;
    }
    GetMovie(id: string): Observable<IResponse<Movie>> {
        return this.httpClient.get<IResponse<Movie>>(`${this.baseUrl}/${id}`);
    }
    createMovie(movie: object): Observable<IResponse<string>> {
        return this.httpClient.post<IResponse<string>>(this.baseUrl, movie);
    }
    UpdateMovie(id: string, movie: FormData): IResponse<Movie> {
        throw new Error("Method not implemented.");
    }
    DeleteMovie(id: string): IResponse<Movie> {
        throw new Error("Method not implemented.");
    }

}