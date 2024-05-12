using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class URYqueryparams:QueryParams
    {
        public string? UniversityName { get; set; }
        public int? Year { get; set; }
        public int? CountryId { get; set; }
    }
}
