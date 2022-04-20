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

            GUI app = new GUI();
            app.renderBase("home");


            while (true) {
                Console.Write("ENTER COMMAND : ");
                try
                {
                    app.handeCommand(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("Command not supported");
                }

            }
        }


    }

}
