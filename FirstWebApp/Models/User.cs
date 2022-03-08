using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class User {
        private int userId;


        public int UserId {
            get { return this.userId; }
            set { if (value>= 0) {
                    this.userId = value;
                  }
            } 
        }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
    }
    
}
