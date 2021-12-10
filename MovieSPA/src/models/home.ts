import { Actor } from './actor';
import { Director } from './director';
import { Movie } from './movie';
export class Home{
    featuredMovies?: Movie[];
    fanFavoritesMovies?: Movie[];
    featuredDirectors?: Director[];
    featuredActors?: Actor[];
    newMovies?: Movie[];
    topPicksMovies?: Movie[];
}