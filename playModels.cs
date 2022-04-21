using System;  
using System.Collections.Generic;


namespace spotify {

    interface IPlayModel {  

        void addSong(SongModel song, int song_id);
        void removeSong(SongModel song, int song_id);
    }





}