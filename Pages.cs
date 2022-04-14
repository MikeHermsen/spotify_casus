using System;  
using System.Collections.Generic;


namespace spotify {

    interface IPage {  

        void renderPage();
    }


    class DefaultPage : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("404 not-found");
        }

    }

    class Home : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("Welcome user");
        }

    }
    class Login : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("login.username your-username");
            Console.WriteLine("login.password your-password");
            Console.WriteLine("login.submit"); 
        }

    }

    class Register : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("register.username your-username");
            Console.WriteLine("register.password your-password");
            Console.WriteLine("register.submit");
        }

    }

    class Dashboard : IPage
    {

        string user_id; 
        public Dashboard(string user_id)
        {
            this.user_id = user_id;
        }
        
        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine($"Account: {this.user_id}");
                Console.WriteLine();

            Console.WriteLine("mediaplayer.panel");
            Console.WriteLine("friends.panel");
            Console.WriteLine("playlist.panel");
            Console.WriteLine("song.panel");
        }

    }

    class MediaPlayer : IPage
    {

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("mediaplayer.panel");
        }

    }

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

    class PlayList : IPage
    {

        AuthModel auth_model;
        int user_id;

        public PlayList(AuthModel auth_model, int user_id)
        {
            this.auth_model = auth_model;
            this.user_id = user_id;
        }

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("playlist.panel");
<<<<<<< HEAD
            Console.WriteLine("goto playlist.view   - See all playlist");
=======
            Console.WriteLine("playlist.view");
>>>>>>> main
        }

        public void playlistView()
        {
            this.auth_model.printPlayLists(this.user_id);
        }

    }


    class SongPage : IPage
    {

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("song.panel");
        }

    }


}