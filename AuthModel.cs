using System;  
using System.Collections.Generic;


namespace spotify {

    class AuthModel {  


        private Dictionary<int, User> UsersDict =  
                new Dictionary<int, User>(); 
        private Dictionary<int, SongModel> SongDict =  
                new Dictionary<int, SongModel>(); 

        private Dictionary<int, PlayListModel> PlayListDict =  
                new Dictionary<int, PlayListModel>(); 
    
        public AuthModel()
        {
            SongDict.Add(
                1, new SongModel(
                    "Hello",
                    120,
                    "d&b", 
                    2
                )
            );

            SongDict.Add(
                2, new SongModel(
                    "Nee",
                    100,
                    "rock", 
                    3
                )
            );

            SongDict.Add(
                3, new SongModel(
                    "Thosiba",
                    90,
                    "classic", 
                    3
                )
            );


            PlayListDict.Add(
                1, new PlayListModel(
                    "Alles",
                    new List<int> {1, 2, 3},
                    3
                )
            );


            PlayListDict.Add(
                2, new PlayListModel(
                    "alleen",
                    new List<int> {1},
                    2
                )
            );

            UsersDict.Add(
                1, new User(
                    "mike_hermsen",
                    "test123",
                    new List<int> {} 
                )
            );

            UsersDict.Add(
                2, new User(
                    "mikey_test",
                    "test123",
                    new List<int> {3}
                )
            );
            
            UsersDict.Add(
                3, new User(
                    "alberto",
                    "test123",
                    new List<int> {2}
                )
            );
        }

        public void printFriendsList(int user_id)
        {
            foreach (int key in UsersDict[user_id].friends) {
                User user = UsersDict[key];

                Console.WriteLine($"friends-username:{user.username}");
            }

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