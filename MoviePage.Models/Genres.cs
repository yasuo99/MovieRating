using FluentValidation;
using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Genres: BaseModel
    {
        public Genres()
        {
            Movies = new HashSet<MovieGenres>();
        }
        public string GenresName { get; set; }
        public virtual IEnumerable<MovieGenres> Movies { get; set; }
    }
    public class TaskGenreValidator: AbstractValidator<Genres>
    {
        public TaskGenreValidator()
        {
            RuleFor(g => g.GenresName).NotEmpty().WithMessage("Genre name cannot be empty");
        }
    }
}
