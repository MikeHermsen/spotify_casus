using System;  
using System.Collections.Generic;


namespace spotify {

    class Dashboard : IPage
    {

        string user_id; 
        public Dashboard(string user_id)
        {
            this.user_id = user_id;
        }
        
        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine($"Account: {this.user_id}");
                Console.WriteLine();

            Console.WriteLine("mediaplayer.panel");
            Console.WriteLine("friends.panel");
            Console.WriteLine("playlist.panel");
            Console.WriteLine("song.panel");
        }

    }


}