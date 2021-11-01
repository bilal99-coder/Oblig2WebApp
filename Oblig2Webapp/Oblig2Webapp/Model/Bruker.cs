using System;
using System.ComponentModel.DataAnnotations;

namespace Oblig2Webapp.Model
{
    public class Bruker
    {

        public int BId; 
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public String Brukernavn { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,15}$")]
        public String Passord { get; set; }
    }
}
