using System.Reflection;
using System;  
using System.Collections.Generic;

namespace spotify {
    class User {

        public bool is_authenticated = false;
        public string username;
        public string password;

        List<SongModel> SongList     = new List<SongModel>();
                
        public User() 
        {

        }

        public User(string username, string password) 
        {
            this.username = username;
            this.password = password;

        }
    }

}
