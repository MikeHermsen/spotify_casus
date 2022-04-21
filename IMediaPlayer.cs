using System;  
using System.Collections.Generic;


namespace spotify {

    class MediaPlayer : IPage
    {

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
                
            Console.WriteLine("mediaplayer.panel");
            Console.WriteLine("mediaplayer.play {song_id}");
            Console.WriteLine("mediaplayer.remove {song_id}");
            Console.WriteLine("mediaplayer.add {song_id}");
            Console.WriteLine("mediaplayer.next                 - Next song"); 
            Console.WriteLine("songs.all");
            
        }

    }

}