using System;  


namespace spotify {


    class GUI {  

        public string hold_login_username;
        private User user = new User();

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
            else if ( route == "login" && !user.is_authenticated ) 
            { // LOGINSCREEN
                Console.WriteLine("login.username = your-username");
                Console.WriteLine("login.password = your-password");
                Console.WriteLine("login.submit");
            }
            else if ( route == "register" && !user.is_authenticated)
            { // LOGINSCREEN
                Console.WriteLine("register.username = your-username");
                Console.WriteLine("register.password = your-password");
                Console.WriteLine("register.submit");
            }

            resetGui();
        }

        public void handeCommand(string command) {

            if (command.StartsWith("goto")) 
            {
                string page = command.Split(" ")[1];
                renderBase(page);
            }
            else if ( command.StartsWith("login.username") && !user.is_authenticated) 
            {
                string value = command.Split("=")[1];
                this.hold_login_username = value;
            }
            else if (command == "exit") 
            {
                Console.WriteLine("TOLD YOU NOT TO USE IT!!!");
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
            // Console.BackgroundColor = ConsoleColor.DarkGreen;              
            Console.ForegroundColor = ConsoleColor.White;              
        }

        public void resetGui() {
            // Console.BackgroundColor = ConsoleColor.Gray;              
            Console.ForegroundColor = ConsoleColor.Gray;              
        }

        public void renderHeader(string route) {
            
            string[] navList;
            if (!user.is_authenticated)
            {
                navList = new string[] { "home", "login", "register" };
            } else {
                navList = new string[] { "home" };
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
                "play song {song}           - Plays the song you want.      ", 
                "play playlist {play-list}  - Plays the playlist            ",
                "shuffle {on, off, toggle}  - Shuffle mode                  ",
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