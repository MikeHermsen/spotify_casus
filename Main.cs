using System;  

namespace spotify {
    class Program {


        static void Main(string[] args) {  

            GUI app = new GUI();
            app.renderBase("home");
            

            while (true) {
                Console.Write("ENTER COMMAND : ");
                app.handeCommand(Console.ReadLine());
            }
        }


    }

}
