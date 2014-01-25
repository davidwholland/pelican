using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pelican.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}