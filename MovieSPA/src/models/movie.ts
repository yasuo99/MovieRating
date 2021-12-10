import { Director } from './director';
import { Actor } from "./actor";
import { PG } from "./pg";

export class Movie{
    id: string;
    title: String;
    shortName?: string;
    releasedAt: Date;
    description: string;
    cover: string;
    pg: PG;
    duration: number;
    actors: Actor[];
    directors: Director[]
    rating: number;
    createdAt: Date;
    modifiedAt: Date;
    /**
     *
     */
    constructor() {
        this.id = '';
        this.title = '';
        this.releasedAt = new Date();
        this.description = '',
        this.cover = ''
    }
}