using System;  
using System.Collections.Generic;


namespace spotify {



    class PlayList : IPage
    {

        AuthModel auth_model;
        int user_id;

        public PlayList(AuthModel auth_model, int user_id)
        {
            this.auth_model = auth_model;
            this.user_id = user_id;
        }

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();

            Console.WriteLine("playlist.panel");
            
            Console.WriteLine("album.play {id-album}");
            Console.WriteLine("playlist.play {id-playlist}");
            Console.WriteLine("playlist.remove {id-song} {id-playlist}");
            Console.WriteLine("playlist.add {id-song} {id-playlist}");
            Console.WriteLine("goto playlist.view               - See all playlist");
            Console.WriteLine("playlist.view-id   {user_id}     - See all playlist of user");
        }

        public void playlistView()
        {
            this.auth_model.printPlayLists(this.user_id);
        }

    }


}