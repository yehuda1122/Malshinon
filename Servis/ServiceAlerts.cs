using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Malshinon
{
    internal class ServiceAlerts
    {
        public static void CheckIfIsDangerous(int TargetId)
        {
            int Num_mentions = PepolelDal.GetNum_mentions(TargetId);
            if (Num_mentions > 3)
            {
                AlertsDal.AddAlerts(TargetId, "Mor Then 20 report");
            }
        }
    }

    // בדיקה אם אדם מסוכן לפי שם
    //public static void  CheckIfIsDangerousByName()
    //{
    //    Console.WriteLine("Enter FullName:");
    //    string FullName = Console.ReadLine();
    //    int IdTarget = 0;
    //    if (PepolelDal.CheackIfFullNameExsist(FullName))
    //    {
    //        IdTarget = PepolelDal.CheckIfExistsCodeNameOrName(FullName);
    //        int Num_mentions = PepolelDal.GetNum_mentions(IdTarget);

    //        if (Num_mentions >= 20)
    //        {
    //            Console.WriteLine("Dangerous");
    //        }

    //        Console.WriteLine("Teh Person Not Dangerous ");

    //    }
    //    Console.WriteLine("The Name Not Exists");
    //}


}
