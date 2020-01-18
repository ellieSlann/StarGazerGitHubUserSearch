using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerProjectMark2.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string Avatar { get; set; }
        public string Location { get; set; }
        public int NumberOfRepos { get; set; }
    }
}