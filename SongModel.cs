using System;  
using System.Collections.Generic;


namespace spotify {

    class SongModel {  

        public string title;
        public int duration;
        public string genre;
        public int artist;

        public SongModel(string title, int duration, string genre, int artist)
        {
            this.title = title;
            this.duration = duration;
            this.genre = genre;
            this.artist = artist;
        }

    }
}