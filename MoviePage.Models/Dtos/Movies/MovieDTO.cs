using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Movies
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Trailer { get; set; }
        public DateTime ReleasedAt { get; set; }
        public double Budget { get; set; }
        public double BoxOffice { get; set; }
        public bool OnShowing { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public double Rating { get; set; }
        public int TotalRating { get; set; }
    }
}
