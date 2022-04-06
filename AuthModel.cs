using System;  
using System.Collections.Generic;


namespace spotify {

    class AuthModel {  


        private Dictionary<int, User> UsersDict =  
                new Dictionary<int, User>(); 
    
        public AuthModel()
        {
            UsersDict.Add(
                1, new User(
                    "mike_hermsen",
                    "test123" 
                )
            );

            UsersDict.Add(
                2, new User(
                    "mikey_test",
                    "test123"
                )
            );
            
            UsersDict.Add(
                3, new User(
                    "alberto",
                    "test123"
                )
            );
        }

        public void logoutUser(int user_id)
        {
            User user = UsersDict[user_id];
            user.is_authenticated = true;
            UsersDict[user_id] = user;
        }

        public string getUsername(int user_id)
        {
            User user = UsersDict[user_id];
            return user.username;
        }

        public int loginUser(string posted_username, string posted_password)
        {

            foreach (int key in UsersDict.Keys) {
                User user = UsersDict[key];

                if (user.password == posted_password && user.username == posted_username) 
                {
                    user.is_authenticated = true;
                    UsersDict[key] = user;

                    return key;
                } 
            }

            return 0;
            
        }

    }

}