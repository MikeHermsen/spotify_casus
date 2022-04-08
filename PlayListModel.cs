using System;  
using System.Collections.Generic;


namespace spotify {

    class PlayListModel {  

        public string title;
        public List<int> songs;
        public int artist;


        public PlayListModel(string title, List<int> songs, int artist) 
        {
            this.title = title;
            this.songs = songs;
            this.artist = artist;

        }
    }
}