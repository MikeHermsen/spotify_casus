using System;  
using System.Collections.Generic;


namespace spotify {


    class DefaultPage : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("404 not-found");
        }

    }

}