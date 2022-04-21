using System;  
using System.Collections.Generic;

namespace spotify {

    class GUI {  


        public string hold_login_username;      // Dit is voor inlog & register
        public string hold_login_password;      // Dit is voor inlog & register 
        private string cache;                   // Command caching
        int user_id                         = 0;                    // User id    
        public AuthModel Auth               = new AuthModel();
        public MediaController mediaPlayer  = new MediaController();

        public void renderBase(string route) {
            // Maakt de console leeg
            ClearGUI();
            // Console.WriteLine(mediaPlayer.getRunTime());
            mediaPlayer.updateSongLogic(Auth);
            

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
                PlayList pageObj = new PlayList(Auth, user_id);

                if ( route == "playlist.panel" && user_id != 0)
                { // playlist.panel
                    pageObj.renderPage();
                }   
                else if ( route == "playlist.view" && user_id != 0)
                { // playlist.view
                    pageObj.playlistView();
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

            // TESTS
            else if ( command.StartsWith("fast.login") ) {
                user_id = Auth.loginUser("mike_hermsen", "test123");
            } 

            else if ( command.StartsWith("test.login") ) 
            {

                // test-1: login zonder username of password
                this.hold_login_password = null;
                this.hold_login_username = null;
                handeCommand("login.submit");

                // test-2: login zonder password
                handeCommand("login.username test");
                handeCommand("login.submit");

                this.hold_login_username = null;
                handeCommand("login.password test");
                handeCommand("login.submit");

                // Daadwerkelijke login 
                handeCommand("login.username mike_hermsen");
                handeCommand("login.password test123");
                handeCommand("login.submit");
            }
            else if ( command.StartsWith("test.mediaplayer.play") ) 
            {

                // PLAY LOGIC TEST
                handeCommand("mediaplayer.play 2");
                handeCommand("mediaplayer.play 3");
                handeCommand("mediaplayer.play 4");
                handeCommand("mediaplayer.play -4");
                handeCommand("mediaplayer.play");
                handeCommand("mediaplayer.play test");
                handeCommand("mediaplayer.play _");
            }
            else if ( command.StartsWith("test.mediaplayer.add") ) 
            {
                // ADD LOGIC TEST
                handeCommand("mediaplayer.add 1");
                handeCommand("mediaplayer.add 3");
                handeCommand("mediaplayer.add 2");
                handeCommand("mediaplayer.add 4");
                handeCommand("mediaplayer.add -4");
                handeCommand("mediaplayer.add");
                handeCommand("mediaplayer.add test");
                handeCommand("mediaplayer.add _");

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

            else if ( command.StartsWith("register.username") && user_id == 0) 
            {
                string value = command.Split(" ")[1];
                this.hold_login_username = value;
            }
            else if ( command.StartsWith("register.password") && user_id == 0) 
            {
                string value = command.Split(" ")[1];
                this.hold_login_password = value;
            }
            else if ( command.StartsWith("register.submit") && user_id == 0) 
            {
                Auth.registerUser(this.hold_login_username, this.hold_login_password);
                user_id = Auth.loginUser(this.hold_login_username, this.hold_login_password);
                
                if ( user_id != 0 )
                {
                    renderBase("dashboard");
                } else {
                    Console.WriteLine("Incorrect credentials given");
                }
            }
            
            
            else if ( command.StartsWith("mediaplayer.play") && user_id != 0) 
            {
                if(!int.TryParse(command.Split(" ")[1], out int value)) return;

                int song_id = int.Parse(command.Split(" ")[1]);
                mediaPlayer.playSongWithID(song_id, Auth);
                renderBase("mediaplayer.panel");
            }
            else if ( command.StartsWith("mediaplayer.remove") && user_id != 0) 
            {
                if(!int.TryParse(command.Split(" ")[1], out int value)) return;
                int song_id = int.Parse(command.Split(" ")[1]);
                mediaPlayer.removePlaySongWithID(song_id);
                renderBase("mediaplayer.panel");
            }
            else if ( command.StartsWith("mediaplayer.add") && user_id != 0) 
            {
                if(!int.TryParse(command.Split(" ")[1], out int value)) return;
                int song_id = int.Parse(command.Split(" ")[1]);
                mediaPlayer.addSongWithID(song_id, Auth);
                renderBase("mediaplayer.panel");
            }
            else if ( command.StartsWith("mediaplayer.pause") && user_id != 0) 
            {
                mediaPlayer.togglePauseSong();
                renderBase("mediaplayer.panel");
            }

            else if ( command.StartsWith("songs.all") && user_id != 0) 
            {
                renderBase("mediaplayer.panel");
                Auth.printAllSongs();
            }

            else if ( command.StartsWith("playlist.view-id") && user_id != 0) 
            {
                int profile_id = int.Parse(command.Split(" ")[1]);
                Auth.printPlayListsWithId(profile_id );

            }
            else if ( command.StartsWith("playlist.play") && user_id != 0) 
            {
                int playlist_id = int.Parse(command.Split(" ")[1]);
                List<int> playList = Auth.fetchPlayListsWithId(playlist_id);
                mediaPlayer.importSongsFromList(playList);
                mediaPlayer.updateSongLogic(Auth);

            }
            else if ( command.StartsWith("playlist.add") && user_id != 0) 
            {
                int song_id = int.Parse(command.Split(" ")[1]);
                int playlist_id = int.Parse(command.Split(" ")[2]);

                Auth.addSongToPlayListWithId(user_id, song_id, playlist_id);
            }
            else if ( command.StartsWith("playlist.remove") && user_id != 0) 
            {
                int song_id = int.Parse(command.Split(" ")[1]);
                int playlist_id = int.Parse(command.Split(" ")[2]);

                Auth.removeSongFromPlayListWithId(user_id, song_id, playlist_id);
            }

            else if ( command.StartsWith("album.play") && user_id != 0) 
            {
                int album_id = int.Parse(command.Split(" ")[1]);
                List<int> album = Auth.fetchAlbumListsWithId(album_id);
                mediaPlayer.importSongsFromList(album);
                mediaPlayer.updateSongLogic(Auth);
            }
            
            // TODO rest van album overzetten vanuit playlist

            else if ( command.StartsWith("song.current") && user_id != 0) 
            {
                mediaPlayer.currentSongPlaying(Auth);
            }
            else if ( command.StartsWith("mediaplayer.next") && user_id != 0) 
            {
                mediaPlayer.goToNextSong(Auth);
            }
            else if ( command.StartsWith("song.like") && user_id != 0) 
            {
                int hold_song_id = int.Parse(command.Split(" ")[1]);
                Auth.addSongWithId(user_id, hold_song_id);
                renderBase("song.panel");
            }
            else if ( command.StartsWith("song.dislike") && user_id != 0) 
            {
                int hold_song_id = int.Parse(command.Split(" ")[1]);
                Auth.removeSongWithId(user_id, hold_song_id);
                renderBase("song.panel");
            }



            else if ( command.StartsWith("friends.add") && user_id != 0) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.addFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friends.remove") && user_id != 0) 
            {
                int friend_id = int.Parse(command.Split(" ")[1]);
                Auth.removeFriendWithId(user_id, friend_id);
                renderBase("friends.panel");
            }
            else if ( command.StartsWith("friends.profile") && user_id != 0) 
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