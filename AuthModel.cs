using System;  
using System.Collections.Generic;


namespace spotify {

    class AuthModel {  


        private Dictionary<int, User> UsersDict =  
                new Dictionary<int, User>(); 
        private Dictionary<int, SongModel> SongDict =  
                new Dictionary<int, SongModel>(); 

        private Dictionary<int, Afspeellijst> afspeellijst =  
                new Dictionary<int, Afspeellijst>(); 
    
        private Dictionary<int, Album> album =  
                new Dictionary<int, Album>(); 
    
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



            album.Add(
                1, new Album(
                    "Alles",
                    new List<int> {2, 3},
                    3
                )
            );


            afspeellijst.Add(
                1, new Afspeellijst(
                    "Alles",
                    new List<int> {1, 2},
                    3
                )
            );


            afspeellijst.Add(
                2, new Afspeellijst(
                    "alleen",
                    new List<int> {1},
                    2
                )
            );

            UsersDict.Add(
                1, new User(
                    "mike_hermsen",
                    "test123",
                    new List<int> {2} 
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

        public void printFriendProfileById(int friend_id) 
        {
            User user = UsersDict[friend_id];
            Console.WriteLine($"Name:    {friend_id}");
            Console.WriteLine($"username:    {user.username}");
            foreach (int friend_of_user in user.friends)
            {
                Console.WriteLine($"Friends name:    {getUsername(friend_of_user)}");
            }
        }

        public void addFriendWithId(int user_id, int friend_id)
        {
            User user = UsersDict[user_id];
            if ( user.friends.Contains(friend_id) ) 
            {
                Console.WriteLine("Friend already existing.");
            } else {

                user.friends.Add(friend_id);
                UsersDict[user_id] = user;
            }

        }

        public void removeFriendWithId(int user_id, int friend_id)
        {
            User user = UsersDict[user_id];
            if ( user.friends.Contains(friend_id) ) 
            {
                user.friends.Remove(friend_id);
                UsersDict[user_id] = user;

            }
        }

        public void printFriendsList(int user_id)
        {
            foreach (int key in UsersDict[user_id].friends) {
                User user = UsersDict[key];

                Console.WriteLine($"friends-username:{key} - {user.username}");
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