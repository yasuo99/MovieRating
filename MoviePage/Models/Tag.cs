using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Tag: BaseModel
    {
        public string TagName { get; set; }
        public virtual IEnumerable<MovieTag> Movies { get; set; }
    }
}
