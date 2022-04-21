using System;  
using System.Collections.Generic;


namespace spotify {


    class Register : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("register.username your-username");
            Console.WriteLine("register.password your-password");
            Console.WriteLine("register.submit");
        }

    }


}