using System;  
using System.Collections.Generic;


namespace spotify {

    class AuthModel {  


        private Dictionary<int, User> UsersDict =  
                new Dictionary<int, User>(); 
        private Dictionary<int, SongModel> SongDict =  
                new Dictionary<int, SongModel>(); 

        private Dictionary<int, AfspeelLijst> afspeellijst =  
                new Dictionary<int, AfspeelLijst>(); 
    
        private Dictionary<int, Album> album =  
                new Dictionary<int, Album>(); 
    
        public AuthModel()
        {
            SongDict.Add(
                1, new SongModel(
                    "Hello world & D&B Style",
                    80,
                    "d&b", 
                    2
                )
            );

            SongDict.Add(
                2, new SongModel(
                    "Gopnik hardstyle",
                    120,
                    "DJ Blyatman", 
                    3
                )
            );

            SongDict.Add(
                3, new SongModel(
                    "Never gonna give you up",
                    60,
                    "Die rooie", 
                    3
                )
            );

            afspeellijst.Add(
                1, new AfspeelLijst(
                    "van alles en nog wat",
                    new List<int> {1, 2},
                    1
                )
            );

            afspeellijst.Add(
                2, new AfspeelLijst(
                    "DJ mixer",
                    new List<int> {3},
                    2
                )
            );

            afspeellijst.Add(
                4, new AfspeelLijst(
                    "CopyRight not existing",
                    new List<int> {1, 2, 3},
                    2
                )
            );

            afspeellijst.Add(
                3, new AfspeelLijst(
                    "MikeySpikes",
                    new List<int> {1, 2},
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

            UsersDict.Add(
                1, new User(
                    "mike_hermsen",
                    "test123",
                    new List<int> {2},
                    new List<int> {2} 
                )
            );

            UsersDict.Add(
                2, new User(
                    "mikey_test",
                    "test123",
                    new List<int> {2},
                    new List<int> {1, 2, 3}
                )
            );
            
            UsersDict.Add(
                3, new User(
                    "alberto",
                    "test123",
                    new List<int> {2},
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
                Console.WriteLine($"Friends name: {friend_of_user} - {getUsername(friend_of_user)}");

            foreach (int liked_song in user.liked_songs)
                Console.WriteLine($"Liked song name: {liked_song} - {getCurrentSongByID(liked_song).title}");

        }
        public SongModel getCurrentSongByID(int song_id) 
        {
            SongModel song = SongDict[song_id];
            return song;

        }


        public void addFriendWithId(int user_id, int friend_id)
        {
            User user = UsersDict[user_id];
            if ( user_id == friend_id ) return;


            if ( user.friends.Contains(friend_id) ) 
            {
                Console.WriteLine("Friend already existing.");
                return;
            } 

            user.friends.Add(friend_id);
            UsersDict[user_id] = user;

        }

        public void createAlbum(string title, int user_id) 
        {
            album.Add(
                album.Count + 1, new Album(
                    title,
                    new List<int> {},
                    user_id
                )
            );

        }

        public void createAfspeellijst(string title, int user_id) 
        {
            afspeellijst.Add(
                afspeellijst.Count + 1, new AfspeelLijst(
                    title,
                    new List<int> {},
                    user_id
                )
            );
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


        public void addSongWithId(int user_id, int song_id)
        {
            User user = UsersDict[user_id];

            if ( user.liked_songs.Contains(song_id) ) 
            {
                Console.WriteLine("Song already existing.");
                return;
            } 

            user.liked_songs.Add(song_id);
            UsersDict[user_id] = user;

        }


        public void addSongToPlayListWithId(int user_id, int song_id, int afspeellijst_id)
        {
            User user                           = UsersDict[user_id];
            SongModel song_entity               = SongDict[song_id];
            AfspeelLijst afspeellijst_entity    = afspeellijst[afspeellijst_id];
            

            if (afspeellijst_entity.author != user_id) 
            {
                Console.WriteLine("Mag geen bewerking doen aan playlist omdat de afspeellijst niet door jouw is aangemaakt.");
                return;
            }


            printPlayListsWithId(user_id);
            afspeellijst_entity.addSong(song_entity, song_id);

        }


        public void removeSongFromPlayListWithId(int user_id, int song_id, int afspeellijst_id)
        {
            User user                           = UsersDict[user_id];
            SongModel song_entity               = SongDict[song_id];
            AfspeelLijst afspeellijst_entity    = afspeellijst[afspeellijst_id];
            

            if (afspeellijst_entity.author != user_id) 
            {
                Console.WriteLine("Mag geen bewerking doen aan playlist omdat de afspeellijst niet door jouw is aangemaakt.");
                return;
            }


            afspeellijst_entity.removeSong(song_entity, song_id);
            printPlayListsWithId(user_id);

        }




        public void addSongToAlbumWithId(int user_id, int song_id, int album_id)
        {
            User user                           = UsersDict[user_id];
            SongModel song_entity               = SongDict[song_id];
            Album album_entity    = album[album_id];
            

            if (album_entity.author != user_id) 
            {
                Console.WriteLine("Mag geen bewerking doen aan playlist omdat de afspeellijst niet door jouw is aangemaakt.");
                return;
            }


            printAlbumWithId(user_id);
            album_entity.addSong(song_entity, song_id);

        }


        public void removeSongFromAlbumWithId(int user_id, int song_id, int album_id)
        {
            User user                           = UsersDict[user_id];
            SongModel song_entity               = SongDict[song_id];
            Album album_entity    = album[album_id];
            

            if (album_entity.author != user_id) 
            {
                Console.WriteLine("Mag geen bewerking doen aan playlist omdat de afspeellijst niet door jouw is aangemaakt.");
                return;
            }


            album_entity.removeSong(song_entity, song_id);
            printAlbumWithId(user_id);

        }


        public void removeSongWithId(int user_id, int song_id)
        {
            User user = UsersDict[user_id];
            if ( user.liked_songs.Contains(song_id) ) 
            {
                user.liked_songs.Remove(song_id);
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

        public void printAllSongs()
        {
            foreach (int key in SongDict.Keys) {
                SongModel song = SongDict[key];

                Console.WriteLine($"song : {key} - {song.title}");
            }

        }

        

        public void printAlbumWithId(int user_id)
        {
            Console.WriteLine($"fetching songs");
            foreach (int key in album.Keys) 
            {

                    Console.WriteLine("");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("");

                if (album[key].author == user_id) {
                    Console.WriteLine("Playlist belongs to you");
                }

                Console.WriteLine($"-Afspeelijst-id:      {key}");
                Console.WriteLine($"-Afspeelijst-name:      {album[key].title}");
                Console.WriteLine($"-Afspeelijst-artis:     {UsersDict[album[key].author].username}");
                foreach (int song_key in album[key].songs) 
                {
                    Console.WriteLine("----------------------");
                    SongModel song = SongDict[song_key];
                    Console.WriteLine($"song-id:     {song_key}");
                    Console.WriteLine($"song-title:     {song.title}");
                    Console.WriteLine($"song-duration:  {song.duration}");
                    Console.WriteLine($"song-genre:     {song.genre}");
                    Console.WriteLine($"song-artist:    {UsersDict[song.artist].username}");

                }

            }
            
        }

        public void printPlayLists(int user_id)
        {
            Console.WriteLine($"fetching songs");
            foreach (int key in afspeellijst.Keys) 
            {

                    Console.WriteLine("");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("");

                if (afspeellijst[key].author == user_id) {
                    Console.WriteLine("Playlist belongs to you");
                }

                Console.WriteLine($"-Afspeelijst-id:      {key}");
                Console.WriteLine($"-Afspeelijst-name:      {afspeellijst[key].title}");
                Console.WriteLine($"-Afspeelijst-artis:     {UsersDict[afspeellijst[key].author].username}");
                foreach (int song_key in afspeellijst[key].songs) 
                {
                    Console.WriteLine("----------------------");
                    SongModel song = SongDict[song_key];
                    Console.WriteLine($"song-id:     {song_key}");
                    Console.WriteLine($"song-title:     {song.title}");
                    Console.WriteLine($"song-duration:  {song.duration}");
                    Console.WriteLine($"song-genre:     {song.genre}");
                    Console.WriteLine($"song-artist:    {UsersDict[song.artist].username}");

                }

            }
            
        }




        public void printAlbumLists(int user_id)
        {
            Console.WriteLine($"fetching songs");
            foreach (int key in album.Keys) 
            {

                    Console.WriteLine("");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("");

                if (album[key].author == user_id) {
                    Console.WriteLine("Playlist belongs to you");
                }

                Console.WriteLine($"-Album-id:      {key}");
                Console.WriteLine($"-Album-name:      {album[key].title}");
                Console.WriteLine($"-Album-artis:     {UsersDict[album[key].author].username}");
                foreach (int song_key in album[key].songs) 
                {
                    Console.WriteLine("----------------------");
                    SongModel song = SongDict[song_key];
                    Console.WriteLine($"song-id:     {song_key}");
                    Console.WriteLine($"song-title:     {song.title}");
                    Console.WriteLine($"song-duration:  {song.duration}");
                    Console.WriteLine($"song-genre:     {song.genre}");
                    Console.WriteLine($"song-artist:    {UsersDict[song.artist].username}");

                }

            }
            
        }

        public List<int> fetchPlayListsWithId(int playListid) 
        {
            Console.WriteLine("Play song list called");
            List<int> temp_list = new List<int> {};

            if (!afspeellijst.ContainsKey(playListid))  return temp_list;
            

            // Console.WriteLine($" the songs {afspeellijst[playListid].songs}");

            return afspeellijst[playListid].songs;
        }

        public List<int> fetchAlbumListsWithId(int albumListid) 
        {
            Console.WriteLine("Play song list called");
            List<int> temp_list = new List<int> {};

            if (!album.ContainsKey(albumListid))    return temp_list;
            

            // Console.WriteLine($" the songs {album[albumListid].songs}");

            return album[albumListid].songs;
        }


        public bool songExistInDict(int song_id) 
        {
            return SongDict.ContainsKey(song_id);
        }

        public void printPlayListsWithId(int profile_id)
        {
            Console.WriteLine($"fetching songs");
            foreach (int key in afspeellijst.Keys) 
            {
                if (afspeellijst[key].author != profile_id)
                {
                    continue;
                }

                Console.WriteLine("");
                Console.WriteLine("----------------------");
                Console.WriteLine("");


                Console.WriteLine($"-Afspeelijst-id:      {key}");
                Console.WriteLine($"-Afspeelijst-name:      {afspeellijst[key].title}");
                Console.WriteLine($"-Afspeelijst-artis:     {UsersDict[afspeellijst[key].author].username}");
                foreach (int song_key in afspeellijst[key].songs) 
                {
                    Console.WriteLine("----------------------");
                    SongModel song = SongDict[song_key];
                    Console.WriteLine($"song-id:     {song_key}");
                    Console.WriteLine($"song-title:     {song.title}");
                    Console.WriteLine($"song-duration:  {song.duration}");
                    Console.WriteLine($"song-genre:     {song.genre}");
                    Console.WriteLine($"song-artist:    {UsersDict[song.artist].username}");

                }

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


        public void registerUser(string posted_username, string posted_password)
        {

            bool user_exist = false;
            foreach (int key in UsersDict.Keys) {
                User user = UsersDict[key];

                if (user.username == posted_username) 
                {
                    user_exist = true;
                    break; 
                } 
            }

            if ( !user_exist ) 
            {
                UsersDict.Add(
                    UsersDict.Count + 1, new User(
                        posted_username,
                        posted_password,
                        new List<int> {}
                    )
                );                
            }

            
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