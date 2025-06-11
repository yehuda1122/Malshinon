using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Malshinon
{
    internal class ServicePerson
    {

        public static void AddNewPerson(string CodeNameOrFullName)
        {
            var pars = CodeNameOrFullName.Split();
            if (pars.Length >= 2)
            {
                Console.WriteLine("Enter SecretCode");
                string SecretCode = Console.ReadLine();
                PepolelDal.AddPerson(CodeNameOrFullName, SecretCode);
                
            }

            Console.WriteLine("Enter FullName");
            string FullName = Console.ReadLine();
            PepolelDal.AddPerson(FullName, CodeNameOrFullName);

        }

        public static void GetSecretCodeByName()
        {
            Console.WriteLine("Enter Name");
            string FullName = Console.ReadLine();
            
            Console.WriteLine(PepolelDal.GetSecretCodeByName(FullName));
            
        }
    }
}
