using MoviePage.DataAccess.Data;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Seeders
{
    public class DataSeeder
    {
        static Models.Genres action = new Models.Genres
        {
            GenresName = "Action",
        };
        static Models.Genres adventure = new Models.Genres
        {
            GenresName = "Adventure",
        };
        static Models.Genres drama = new Models.Genres
        {
            GenresName = "Drama",
        };
        static Models.Genres fiction = new Models.Genres
        {
            GenresName = "Fiction",
        };
        static Models.Genres comic = new Models.Genres
        {
            GenresName = "Comic",
        };
        static Models.Genres romantic = new Models.Genres
        {
            GenresName = "Romantic",
        };
        static Models.Genres scifi = new Models.Genres
        {
            GenresName = "Sci-Fi",
        };

        static PG pg = new PG
        {
            RestrictAge = 13,
            Title = "PG-13",
            MPAA = "Rated PG-13 for sequences of strong violence, some disturbing images and suggestive material"
        };


        static Actor timothi = new Actor
        {
            FirstName = "Timothée",
            LastName = "Chalamet",
            BirthDate = DateTime.Parse("27 December 1995"),
            Avatar = "https://m.media-amazon.com/images/M/MV5BOWU1Nzg0M2ItYjEzMi00ODliLThkODAtNGEyYzRkZTBmMmEzXkEyXkFqcGdeQXVyNDk2Mzk2NDg@._V1_UY317_CR13,0,214,317_AL_.jpg",
            Sex = Models.Enums.Sex.Male,
        };
        static Actor rebecca = new Actor
        {
            FirstName = "Rebecca",
            LastName = "Ferguson",
            BirthDate = DateTime.Parse("19 October 1983"),
            Avatar = "https://m.media-amazon.com/images/M/MV5BNzA4NDA1MTA5NV5BMl5BanBnXkFtZTcwNjMyNTQ3OA@@._V1_UY317_CR6,0,214,317_AL_.jpg",
            Sex = Models.Enums.Sex.Female,
        };
        static Actor zendaya = new Actor
        {
            FirstName = "Zendaya",
            LastName = "",
            BirthDate = DateTime.Parse("1 September 1996"),
            Avatar = "https://m.media-amazon.com/images/M/MV5BMjAxZTk4NDAtYjI3Mi00OTk3LTg0NDEtNWFlNzE5NDM5MWM1XkEyXkFqcGdeQXVyOTI3MjYwOQ@@._V1_UY317_CR12,0,214,317_AL_.jpg",
            Sex = Models.Enums.Sex.Female,
        };
        static Actor tomHardy = new Actor
        {
            FirstName = "Tom",
            LastName = "Hardy",
            BirthDate = DateTime.Parse("15 September 1977"),
            Avatar = "https://m.media-amazon.com/images/M/MV5BMTQ3ODEyNjA4Nl5BMl5BanBnXkFtZTgwMTE4ODMyMjE@._V1_UX214_CR0,0,214,317_AL_.jpg",
            Sex = Models.Enums.Sex.Male,
        }; 
        static Actor woodyHarrelson = new Actor
        {
            FirstName = "Woody",
            LastName = "Harrelson",
            BirthDate = DateTime.Parse("23 July 1961"),
            Avatar = "https://m.media-amazon.com/images/M/MV5BMTU3NDc2ODc4MF5BMl5BanBnXkFtZTcwODk2MzAyMg@@._V1_UY317_CR1,0,214,317_AL_.jpg",
            Sex = Models.Enums.Sex.Male,
        };


        static Director director = new Director
        {
            FirstName = "Denis",
            LastName = "Villeneuve",
            Avatar = "https://m.media-amazon.com/images/M/MV5BMzU2MDk5MDI2MF5BMl5BanBnXkFtZTcwNDkwMjMzNA@@._V1_UY317_CR0,0,214,317_AL_.jpg",
            BirthDate = DateTime.Parse("3 October 1967"),
            Bio = "Denis Villeneuve is a French Canadian film director and writer. He was born in 1967, in Trois-Rivières, Québec, Canada. He started his career as a filmmaker at the National Film Board of Canada. He is best known for his feature films Arrival (2016), Sicario (2015), Prisoners (2013), Enemy (2013), and Incendies (2010),...",
            Country = "Canada"
        };
        static Director director1 = new Director
        {
            FirstName = "Andy",
            LastName = "Serkis",
            Avatar = "https://m.media-amazon.com/images/M/MV5BYTgwYmM0ZjgtMWRmZC00YTc1LWIwYWEtYTFjMTZiMDNjNWRkXkEyXkFqcGdeQXVyNjcwMjczMzE@._V1_UX214_CR0,0,214,317_AL_.jpg",
            BirthDate = DateTime.Parse("20 April 1964"),
            Bio = "English film actor, director and author Andy Serkis is known for his performance capture roles comprising motion capture acting, animation and voice work for such computer-generated characters as Gollum in The Lord of the Rings film trilogy (2001-2003) and The Hobbit: An Unexpected Journey (2012), the eponymous King Kong in the 2005 film, Caesar ...",
            Country = "Ruislip, London, England, UK"
        };


        static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "Dune: Part One",
                ShortName = "Dune",
                Cover = "https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F61116cea2313e8bae55a536a%2F-Dune-%2F0x0.jpg%3Ffit%3Dscale",
                Duration = 155,
                PG = pg,
                Actors = new List<MovieActor>
                {
                    new MovieActor
                    {
                        Actor = timothi,
                        Role = Models.Enums.ActorRole.MaleLead,
                        Character = "Paul Atreides"
                    },
                    new MovieActor
                    {
                        Actor = rebecca,
                        Role = Models.Enums.ActorRole.FemaleLead,
                        Character = "Lady Jessica Atreides"
                    },
                    new MovieActor
                    {
                        Actor = zendaya,
                        Role = Models.Enums.ActorRole.Supporting,
                        Character = "Chani"
                    }
                },
                Directors = new List<MovieDirector>
                {
                    new MovieDirector
                    {
                        Director = director
                    }
                },
                Genres = new List<MovieGenres>
                {
                    new MovieGenres
                    {
                        Genres = action
                    },
                    new MovieGenres
                    {
                        Genres = adventure
                    },
                    new MovieGenres
                    {
                        Genres = drama
                    }
                },
                Trailer = "https://www.youtube.com/watch?v=8g18jFHCLXk",
                Description = "Feature adaptation of Frank Herbert's science fiction novel, about the son of a noble family entrusted with the protection of the most valuable asset and most vital element in the galaxy.",
                ReleasedAt = DateTime.Parse("3 September 2021"),
                Budget = 165000000,
                BoxOffice = -1,
                IsFeatured = true
            },
             new Movie
            {
                Title = "Dune: Part Two",
                ShortName = "Dune II",
                Cover = "https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F61116cea2313e8bae55a536a%2F-Dune-%2F0x0.jpg%3Ffit%3Dscale",
                Duration = 155,
                PG = pg,
                Directors = new List<MovieDirector>
                {
                    new MovieDirector
                    {
                        Director = director
                    }
                },
                 Genres = new List<MovieGenres>
                {
                    new MovieGenres
                    {
                        Genres = action
                    },
                    new MovieGenres
                    {
                        Genres = adventure
                    },
                    new MovieGenres
                    {
                        Genres = drama
                    }
                },
                Trailer = "https://www.youtube.com/watch?v=8g18jFHCLXk",
                Description = "The next installment in the 'Dune' franchise.",
                ReleasedAt = DateTime.Parse("October 20, 2023"),
                Budget = -1,
                BoxOffice = -1,
                IsFeatured = false
            },
             new Movie
            {
                Title = "Venom: Let There Be Carnage",
                ShortName = "Venom II",
                Cover = "https://m.media-amazon.com/images/M/MV5BNTFiNzBlYmEtMTcxZS00ZTEyLWJmYmQtMjYzYjAxNGQwODAzXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_.jpg",
                Duration = 157,
                PG = pg,
                Actors = new List<MovieActor>
                {
                    new MovieActor
                    {
                        Actor = tomHardy,
                        Role = Models.Enums.ActorRole.MaleLead,
                        Character = "Eddie Brock"
                    },
                    new MovieActor
                    {
                        Actor = woodyHarrelson,
                        Role = Models.Enums.ActorRole.MaleLead,
                        Character = "Cletus Kasady"
                    }
                },
                Directors = new List<MovieDirector>
                {
                    new MovieDirector
                    {
                        Director = director1
                    }
                },
                 Genres = new List<MovieGenres>
                {
                    new MovieGenres
                    {
                        Genres = action
                    },
                    new MovieGenres
                    {
                        Genres = adventure
                    },
                    new MovieGenres
                    {
                        Genres = scifi
                    }
                },
                Trailer = "https://www.youtube.com/watch?v=-FmWuCgJmxo",
                Description = "Eddie Brock attempts to reignite his career by interviewing serial killer Cletus Kasady, who becomes the host of the symbiote Carnage and escapes prison after a failed execution.",
                ReleasedAt = DateTime.Parse("1 October 2021"),
                Budget = -1,
                BoxOffice = 426300000,
                IsFeatured = true
            },
        };
        public static void SeedData(ApplicationDbContext _db)
        {
            // Make sure that all the tables above are empty
            if (_db.Movies.Count() == 0 && _db.Genres.Count() == 0 && _db.Actors.Count() == 0 && _db.Directors.Count() == 0)
            {
                _db.Genres.Add(action);
                _db.Genres.Add(scifi);
                _db.Genres.Add(comic);
                _db.Genres.Add(fiction);
                _db.Genres.Add(romantic);
                _db.Genres.Add(drama);
                _db.Directors.Add(director);
                _db.Directors.Add(director1);
                _db.Actors.Add(timothi);
                _db.Actors.Add(zendaya);
                _db.Actors.Add(rebecca);
                _db.Actors.Add(tomHardy);
                _db.Actors.Add(woodyHarrelson);
                foreach (var movie in movies)
                {
                    _db.Add(movie);
                }
                _db.SaveChanges();
            }

        }
        public static void SeedReview(ApplicationDbContext _db, Guid movieId)
        {

        }
    }
}
