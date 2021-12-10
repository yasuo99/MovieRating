using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Theater: BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<TheaterBranch> TheaterBranches { get; set; }
    }
}
