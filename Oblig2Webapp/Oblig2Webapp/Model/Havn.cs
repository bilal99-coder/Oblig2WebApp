using Oblig2Webapp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2Webapp.Model
{
    public class Havn
    {
        [Key]
        public int HavnId { get; set; }
        public string HavnNavn { get; set; }
        public virtual List<ankomstHavner> AnkomstHavner { get; set; }
    }

}
