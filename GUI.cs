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


            if (route.StartsWith("home"))
            {
                Home pageObj = new Home();

                if ( route == "home" ) 
                { // DE HOMESCREEN 
                    pageObj.renderPage();
                } 
            } 
            
            else if (route.StartsWith("register")) 
            {
                Register pageObj = new Register();

            
                if ( route == "register" && user_id == 0)
                { // REGISTERSCREEN
                    pageObj.renderPage();
                }
            } 
            
            else if (route.StartsWith("login"))
            {
                Login pageObj = new Login();

                if ( route == "login" && user_id == 0 ) 
                { // LOGINSCREEN
                    pageObj.renderPage();
                }
            }

            else if (route.StartsWith("dashboard"))
            {
                Dashboard pageObj = new Dashboard(Auth.getUsername(user_id));
            
                if ( route == "dashboard" && user_id != 0)
                { // Dashboard
                    pageObj.renderPage();
                }
            }

            else if (route.StartsWith("mediaplayer"))
            {
                MediaPlayer pageObj = new MediaPlayer();

                if ( route == "mediaplayer.panel" && user_id != 0)
                { // mediaplayer.panel
                    pageObj.renderPage();
                }
            }

            else if (route.StartsWith("friends")) 
            {
                Friends pageObj = new Friends(user_id, Auth);

                if ( route == "friends.panel" && user_id != 0)
                { // friends.panel
                    pageObj.renderPage();
                }
                else if ( route == "friends.profile" && user_id != 0)
                { // friends.panel
                    pageObj.friendProfile(int.Parse(cache));
                }
            }

            else if (route.StartsWith("playlist"))
            {
                PlayList pageObj = new PlayList();

                if ( route == "playlist.panel" && user_id != 0)
                { // playlist.panel
                    pageObj.renderPage();
                }
            }

            else if (route.StartsWith("song"))
            {
                SongPage pageObj = new SongPage();


                if ( route == "song.panel" && user_id != 0)
                { // song.panel
                    pageObj.renderPage();
                }
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
            else if ( command.StartsWith("friends.add") && user_id == 1) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.addFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friends.remove") && user_id == 1) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.removeFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friends.profile") && user_id == 1) 
            {
                cache = command.Split(" ")[1];
                renderBase("friends.profile");
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