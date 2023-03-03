using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public class Title
    {
        [Key]
        public string tconst { get; set; }
        public string primaryTitle { get; set; }
        public string originalTitle { get; set; }
        public int? startYear { get; set; }
        public int? endYear { get; set; }
    }
}
