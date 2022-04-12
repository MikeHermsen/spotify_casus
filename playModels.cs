using System;  
using System.Collections.Generic;


namespace spotify {

    interface IPlayModel {  

        void addSong();
    }


    class AfspeelLijst : IPlayModel
    {

        public List<int> songs;
        public string title;
        public int author;

        public AfspeelLijst(string title, List<int> songs, int author)
        {
            this.author = author;
            this.title = title;
            this.songs = songs;
        }

        public void addSong() 
        {
            Console.WriteLine("404 not-found");
        }

    }

    class Album : IPlayModel
    {

        List<int> songs;
        string title;
        int author;

        public Album(string title, List<int> songs, int author)
        {
            this.author = author;
            this.title = title;
            this.songs = songs;
        }

        public void addSong() 
        {
            Console.WriteLine("404 not-found");
        }

    }



}