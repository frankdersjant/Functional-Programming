using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.API.DTO
{
    public class CustomerModelDTO
    {
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string Industry { get; set; }
    }
}