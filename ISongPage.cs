using System;  
using System.Collections.Generic;


namespace spotify {


    class SongPage : IPage
    {

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("goto song.panel");
            Console.WriteLine("song.current                                     - view current song"); 
            Console.WriteLine("song.make {title} {duration in sec} {genre}      - maakt song aan"); 
            
        }
        

    }


}