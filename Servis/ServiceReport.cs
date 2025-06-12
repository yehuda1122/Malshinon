using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class ServiceReport
    {
        public static void AdData()
        {
            Console.WriteLine("Enter Full Name or Secret Name For Reporter:");
            string NameReport = Console.ReadLine();
            var ReporterId = ServicePerson.CheckIfExistsCodeNameOrName(NameReport);

            Console.WriteLine("Enter Full Name or Secret Name For Target:");
            string NameTarget = Console.ReadLine();
            var TargetId = ServicePerson.CheckIfExistsCodeNameOrName(NameTarget);

            Console.WriteLine("Enrer The Report");
            string ReportText = Console.ReadLine();

            ReportDal.AddReport(ReporterId, TargetId, ReportText);
            Console.WriteLine("submit report");

            ServiceAlerts.CheckIfIsDangerous(TargetId);
        }

 
    }
        
}
