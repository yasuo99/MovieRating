import { Movie } from "./movie";

export interface ITag{
    tagName: string;
    movies: Movie[]
}
export class Tag{
    tagName: string;
    movies: Movie[]
    constructor() {
        this.tagName = ""
        this.movies = []
    }
}