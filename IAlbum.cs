using System;  
using System.Collections.Generic;


namespace spotify {

    class Album : IPlayModel
    {

        public List<int> songs;
        public string title;
        public int author;

        public Album(string title, List<int> songs, int author)
        {
            this.author = author;
            this.title = title;
            this.songs = songs;
        }

        public void addSong(SongModel song, int song_id) 
        {
            if (this.author != song.artist){
                Console.WriteLine("Geen eigenaar van song");
                return;
            }
            Console.WriteLine($"Adding song {song.title} in afspeellijst {this.title}");
            if ( this.songs.Contains(song_id) ) 
            {
                Console.WriteLine("Song already existing.");
                return;
            } 

            this.songs.Add(song_id);
        }


        public void removeSong(SongModel song, int song_id) 
        {

            if (this.author != song.artist){
                Console.WriteLine("Geen eigenaar van song");
                return;
            }

            Console.WriteLine($"Removing song {song.title} in afspeellijst {this.title}");
            if ( this.songs.Contains(song_id) ) 
            {
                this.songs.Remove(song_id);
                return;
            } 
            Console.WriteLine("Song is not in playlist.");

        }


    }



}