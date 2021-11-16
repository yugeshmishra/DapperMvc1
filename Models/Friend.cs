using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperMvc1.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string ConnectionString { get; set; }
    }
}