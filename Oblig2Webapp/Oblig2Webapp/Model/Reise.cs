using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2Webapp.Model
{
    public class Reise
    {
        [Key]
        public int ReiseId { get; set; }
        public string fra { get; set; }
        public string til { get; set; }
        public int pris { get; set; }

}
}
