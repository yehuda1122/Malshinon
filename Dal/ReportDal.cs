using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agents;

namespace Malshinon
{
    static class ReportDal
    {
        public static void AddReport(int ReporterId, int TargetId, string ReportText )
        {
            DateTime SubmittedAt = DateTime.Now;
            var sql = $"INSERT INTO reports (ReporterId  , TargetId , ReportText, SubmittedAt)" +
                $" VALUES('{ReporterId}','{TargetId}','{ReportText}','{SubmittedAt:yyyy-MM-dd HH:mm:ss}')";
            DBConnection.Execute(sql);

            var updateSql = $"UPDATE people SET NumReport = NumReport + 1 WHERE Id = {ReporterId}";
            DBConnection.Execute(updateSql);

            var updateSql1 = $"UPDATE people SET num_mentions = num_mentions + 1 WHERE Id = {TargetId}";
            DBConnection.Execute(updateSql1);



        }
    }
}
