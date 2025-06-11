using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Malshinon - Community Intel Reprting System");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. submit Report");
                Console.WriteLine("2. Import Reporst from CSV");
                Console.WriteLine("3. Show Secret Code by Name");
                Console.WriteLine("4. Analysis Dashboard");
                Console.WriteLine("5. Exit");

                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": ServisForMenu.AdData();
                        break;

                    case "3":
                        ServisForMenu.GetSecretCodeByName();
                        break;

                }
            }           
                            
        }

        //static public void SubmitReport()
        //{
        //    // Get reporter name
       
        //    // TODO: Check not null

        //    // TODO: Check if exists and if not create in DB

        //    // Get target name
        //    Console.WriteLine("Enter target");
        //    string targetName = Console.ReadLine();
        //    // TODO: Check not null

        //    // TODO: Check if exists and if not create in DB


        //    // create Report in DB
        //}
    }
}
