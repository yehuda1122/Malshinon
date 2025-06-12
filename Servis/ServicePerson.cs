using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Malshinon
{
    internal class ServicePerson
    {

        public static int CheckIfExistsCodeNameOrName(string input)
        {
            int id =PepolelDal.GetIdByCodeName(input);
            if (id != -1)
            {
                return id;
            }
            else { 
                int id2 = PepolelDal.GetIdByFullName(input);
            
            if (id2 != -1)
            {
                return id2;
            }}
            // Create person (not exist yet)
            var RancomGuid = GetRandomGuid();
            PepolelDal.AddPerson(input, RancomGuid);//!!!!!!
            int newId = PepolelDal.GetIdByFullName(input);
            return newId;
        }
        public static void GetSecretCodeByName()
        {
            Console.WriteLine("Enter Name");
            string FullName = Console.ReadLine();
            
            Console.WriteLine(PepolelDal.GetSecretCodeByName(FullName));
            
        }
        public static string GetRandomGuid()
        {
            return Guid.NewGuid().ToString();
        }

        //public static void AddNewPerson(string CodeNameOrFullName)
        //{
        //    var pars = CodeNameOrFullName.Split();
        //    if (pars.Length >= 2)
        //    {
        //        Console.WriteLine("Enter SecretCode");
        //        string SecretCode = Console.ReadLine();
        //        PepolelDal.AddPerson(CodeNameOrFullName, SecretCode);

        //    }

        //    Console.WriteLine("Enter FullName");
        //    string FullName = Console.ReadLine();
        //    PepolelDal.AddPerson(FullName, CodeNameOrFullName);

        //}


    }
}
