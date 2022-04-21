using System;  
using System.Collections.Generic;


namespace spotify {


    class Login : IPage
    {

        public void renderPage() 
        {
            Console.WriteLine("Use goto {page.name} to navigate");
                Console.WriteLine();
            Console.WriteLine("login.username your-username");
            Console.WriteLine("login.password your-password");
            Console.WriteLine("login.submit"); 
        }

    }


}