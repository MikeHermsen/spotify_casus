using System;  
using System.Collections.Generic;


namespace spotify {

    interface listModel {  

        void addSong();
    }

    class Afspeellijst : listModel
    {

        public string title;
        public List<int> songs;
        public int artist;


        public void addSong() 
        {
            Console.WriteLine("ADDING Afspeelijst SONG");
        }

        public Afspeellijst(string title, List<int> songs, int artist) 
        {
            this.title = title;
            this.songs = songs;
            this.artist = artist;

        }
    }
    class Album : listModel
    {

        public string title;
        public List<int> songs;
        public int artist;


    
        public void addSong() 
        {
            Console.WriteLine("ADDING ALBUM SONG");    
        }

        public Album(string title, List<int> songs, int artist) 
        {
            this.title = title;
            this.songs = songs;
            this.artist = artist;

        }
    }
}