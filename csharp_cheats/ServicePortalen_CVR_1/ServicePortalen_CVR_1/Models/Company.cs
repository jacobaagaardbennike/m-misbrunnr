using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models
{
    public class Company
    {
        public string Cvr { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}