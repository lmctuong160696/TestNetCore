using System;
using System.Collections.Generic;

namespace TestNetCore.Model.Models
{
    public partial class Persons
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
    }
}
