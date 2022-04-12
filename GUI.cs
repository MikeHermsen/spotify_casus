using System;  
using System.Collections.Generic;

namespace spotify {

    class GUI {  


        public string hold_login_username;
        public string hold_login_password;
        private string cache;
        int user_id               = 0;
        private List<User> UsersList     = new List<User>();
        public AuthModel Auth = new AuthModel();

        public void renderBase(string route) {
            ClearGUI();

            renderHeader(route);
                Console.WriteLine();
            renderBody(route);
                Console.WriteLine();
            renderFooter();
        }


        public void renderBody(string route) {
            themaGui();

            if ( route == "home" ) 
            { // DE HOMESCREEN 
                Console.WriteLine("Welcome user");
            } 
            
            else if ( route == "login" && user_id == 0 ) 
            { // LOGINSCREEN
                Console.WriteLine("login.username your-username");
                Console.WriteLine("login.password your-password");
                Console.WriteLine("login.submit");
            }
            else if ( route == "register" && user_id == 0)
            { // REGISTERSCREEN
                Console.WriteLine("register.username your-username");
                Console.WriteLine("register.password your-password");
                Console.WriteLine("register.submit");
            }

            // IF AUTHENTICATED
            else if ( route == "dashboard" && user_id != 0)
            { // Dashboard
                Console.WriteLine($"Account: {Auth.getUsername(user_id)}");
                    Console.WriteLine();

                Console.WriteLine("mediaplayer.panel");
                Console.WriteLine("friends.panel");
                Console.WriteLine("playlist.panel");
                Console.WriteLine("song.panel");
            }

            // SECTIONS OF WHEN IS_AUTH
            else if ( route == "mediaplayer.panel" && user_id != 0)
            { // mediaplayer.panel
                Console.WriteLine("mediaplayer.panel");
            }
            else if ( route == "friends.panel" && user_id != 0)
            { // friends.panel
                Console.WriteLine("friends.panel");
                Auth.printFriendsList(user_id);
                Console.WriteLine("friend.add {friend-id}");
                Console.WriteLine("friend.remove {friend-id}");
                Console.WriteLine("friend.profile {friend-id}");

            }
            else if ( route == "friend.profile" && user_id != 0)
            { // friends.panel
                Console.WriteLine("friend.profile");
                Auth.printFriendProfileById(int.Parse(cache));

            }

            else if ( route == "playlist.panel" && user_id != 0)
            { // playlist.panel
                Console.WriteLine("playlist.panel");
            }
            else if ( route == "song.panel" && user_id != 0)
            { // song.panel
                Console.WriteLine("song.panel");
            }

            resetGui();
        }

        public void handeCommand(string command) {

            if (command.StartsWith("goto")) 
            {
                string page = command.Split(" ")[1];
                renderBase(page);
            }

            else if ( command.StartsWith("login.test") && user_id == 0) 
            { // DEBUG LOGIN TODO
                user_id = Auth.loginUser("mike_hermsen", "test123");
                renderBase("friends.panel");
            }


            // LOGIN
            else if ( command.StartsWith("login.username") && user_id == 0) 
            {
                string value = command.Split(" ")[1];
                this.hold_login_username = value;
            }
            else if ( command.StartsWith("login.password") && user_id == 0) 
            {
                string value = command.Split(" ")[1];
                this.hold_login_password = value;
            }
            else if ( command.StartsWith("login.submit") && user_id == 0) 
            {
                user_id = Auth.loginUser(this.hold_login_username, this.hold_login_password);
                if ( user_id != 0 )
                {
                    renderBase("dashboard");
                } else {
                    Console.WriteLine("Incorrect credentials given");
                }
            }
            else if ( command.StartsWith("friend.add") && user_id == 1) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.addFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friend.remove") && user_id == 1) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.removeFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friend.profile") && user_id == 1) 
            {
                cache = command.Split(" ")[1];
                renderBase("friend.profile");
            }

            // EXIT
            else if (command == "exit") 
            {
                Console.WriteLine("TOLD YOU NOT TO USE IT!!!");
            }
            // LOGOUT
            else if (command == "logout" && user_id != 0) 
            {
                Auth.logoutUser(user_id);
                user_id = 0;
                renderBase("home");
            }
            else 
            {
                Console.WriteLine("Command not found");
            }
        }

        public void ClearGUI() {
            Console.Clear();
        }

        public void themaGui() {
            Console.ForegroundColor = ConsoleColor.White;              
        }

        public void resetGui() {
            Console.ForegroundColor = ConsoleColor.Gray;              
        }

        public void renderHeader(string route) {
            
            string[] navList;
            if (user_id == 0)
            {
                navList = new string[] { "home", "login", "register" };
            } else {
                navList = new string[] { "home", "dashboard", "mediaplayer.panel", "friends.panel", "playlist.panel", "song.panel" };
            }

            foreach (var route_src in navList)
            {
                if (route_src == route) {
                    // Console.BackgroundColor = ConsoleColor.Green;              
                    Console.ForegroundColor = ConsoleColor.White;              
                } else {
                    // Console.BackgroundColor = ConsoleColor.DarkGreen;              
                    Console.ForegroundColor = ConsoleColor.Green;              
                }


                Console.Write($"     {route_src} ");        
            }

            Console.WriteLine();

            
            resetGui();

        }


        public void renderFooter() {
            
            string[] commandList = new string[] {
                    "goto {menu-item}           - Navigating to different screen", 
                    // "play song {song}           - Plays the song you want.      ", 
                    // "play playlist {play-list}  - Plays the playlist            ",
                    // "shuffle {on, off, toggle}  - Shuffle mode                  ",
                    "exit                       - Never ever ever use this      " };

            foreach (var command in commandList)
            {
                // Console.BackgroundColor = ConsoleColor.White;              
                Console.ForegroundColor = ConsoleColor.DarkGreen;              

                Console.Write($">    {command} ");        
                Console.WriteLine();
            }

            resetGui();

        }


    }  
}