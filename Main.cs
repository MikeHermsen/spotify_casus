using System;  
using System.Collections.Generic;




    
// #7#01001101#01101001#01101011#01100101#01111001#01011111#7#
// #7                                                       7#
// #7   .------..------..------..------..------..------.    7#
// ##   |M.--. ||I.--. ||K.--. ||E.--. ||Y.--. ||_.--. |    ##
// #1   | (\/) || (\/) || :/\: || (\/) || (\/) || :/\: |    1#
// #0   | :\/: || :\/: || :\/: || :\/: || :\/: || :\/: |    0#
// #5   | '--'M|| '--'I|| '--'K|| '--'E|| '--'Y|| '--'_|    5#
// ##   `------'`------'`------'`------'`------'`------'    ##
// #1                                                       1#
// #0   Created by: Mikey_                                  0#
// #7   GitHub: https://github.com/MikeHermsen              7#
// ##                                                       ##
// #1                                                       1#
// #0   For questions you can email                         0#
// #1   MikeHermsenPrive+Code@Gmail.com                     1#
// ##                                                       ##
// #1                                                       1#
// #2   https://DevMikey.com/                               2#
// #1   https://GigaFix.nl/                                 1#
// ##                                                       ##
// #9                                                       9#
// #5#01001101#01101001#01101011#01100101#01111001#01011111#5#




namespace spotify {
    class Program {


        static void Main(string[] args) {  

            // Maakt de GUI en rendered de dashboard
            GUI app = new GUI();
            app.renderBase("home");


            // MAIN STREAM - Hier word de input gevraagt
            while (true) {
                Console.Write("ENTER COMMAND : ");
                try
                {
                    // Hier kijkt de functie wat er gedaan moet worden met de gevraagte input
                    app.handeCommand(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("Kommand is niet gevonden. Is het goed geschreven?");
                }

            }
        }


    }

}
