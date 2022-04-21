using System;  
using System.Collections.Generic;


namespace spotify {


    class Friends : IPage
    {
        AuthModel auth_model;
        int user_id;
        public Friends(int user_id, AuthModel auth_model)
        {
            this.auth_model = auth_model;
            this.user_id = user_id;
        }
        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
        
                Console.WriteLine("friends.panel");
                
                auth_model.printFriendsList(user_id);

                Console.WriteLine("friends.add {friend-id}");
                Console.WriteLine("friends.remove {friend-id}");
                Console.WriteLine("friends.profile {friend-id}");
        }

        public void friendProfile(int user_id)
        {
            Console.WriteLine("friend.profile");
            auth_model.printFriendProfileById(user_id);
        }

    }

}