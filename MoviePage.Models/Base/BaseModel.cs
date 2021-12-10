using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models.Base
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

    }
}
