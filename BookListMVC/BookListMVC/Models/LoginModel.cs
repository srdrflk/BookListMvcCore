using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
       
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
