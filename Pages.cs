using System;  
using System.Collections.Generic;


namespace spotify {

    interface Page {  

        void renderPage();
    }

    class Afspeellijst : Page
    {

        public string title;
        public List<int> songs;
        public int artist;


        public void renderPage() 
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
    class Album : Page
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