using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Viewer.Web.Models
{
    public class GeoCodeCities
    {
        [Display(Name = "Description")]
        public string fcodeName { get; set; }

        [Display(Name = "Name")]
        public string toponymName { get; set; }

        [Display(Name = "Country Code")]
        public string countrycode { get; set; }

        public string fcl { get; set; }

        public string fclName { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Wikipedia")]
        public string wikipedia { get; set; }

        [Display(Name = "Longitude")]
        public decimal lng { get; set; }

        public string fcode { get; set; }

        [Display(Name = "City Id")]
        public int geonameId { get; set; }

        [Display(Name = "Latitude")]
        public decimal lat { get; set; }

        [DisplayFormat(DataFormatString = "{0:0,0}")]
        [Display(Name = "Population")]
        public int population { get; set; }
    }
}