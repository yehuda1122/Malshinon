using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agents;
using Mysqlx.Crud;

namespace Malshinon
{
    internal class AlertsDal
    {
        public static void AddAlerts(int TargetId, string Reason)
        {
            DateTime CreatedAt = DateTime.Now;

            var Sql = $"INSERT INTO alerts (TargetId, Reason)" +
                $"VALUES({TargetId},'{Reason}')";
            DBConnection.Execute(Sql);
        }
    }
}
