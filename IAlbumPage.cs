using System;  
using System.Collections.Generic;


namespace spotify {



    class IAlbumPage : IPage
    {

        AuthModel auth_model;
        int user_id;

        public IAlbumPage(AuthModel auth_model, int user_id)
        {
            this.auth_model = auth_model;
            this.user_id = user_id;
        }

        public void renderPage()
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();

            Console.WriteLine("album.panel");
            
            Console.WriteLine("album.play {id-album}");
            Console.WriteLine("album.play {id-album}");
            Console.WriteLine("album.remove {id-song} {id-album}");
            Console.WriteLine("album.add {id-song} {id-album}");
            Console.WriteLine("goto album.view               - See all album");
            Console.WriteLine("album.view-id   {user_id}     - See all album of user");
        }

        public void albumView()
        {
            this.auth_model.printAlbumLists(this.user_id);
        }

    }


}