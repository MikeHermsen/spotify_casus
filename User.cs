using System.Reflection;
using System;  
using System.Collections.Generic;

namespace spotify {
    class User {

        public bool is_authenticated = false;
        public string username;
        public int id;
        public string password;
        public new List<int> friends;

                
        public User() 
        {

        }

        public User(string username, string password, List<int> friends) 
        {
            this.friends  = friends;
            this.username = username;
            this.password = password;

        }
    }

}
