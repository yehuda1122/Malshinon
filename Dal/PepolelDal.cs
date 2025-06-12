using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agents;
using MySqlX.XDevAPI.Common;

namespace Malshinon
{
    static class PepolelDal
    {
        public static int CheckIfExistsCodeNameOrName(string input)
        {
            string sql = $"SELECT Id FROM people WHERE SecretCode = '{input}'";
            var result = DBConnection.Execute(sql);

            if (result.Count > 0 && result[0]["Id"] != null)
            {
                return Convert.ToInt32(result[0]["Id"]);
            }

            string sql2 = $"SELECT Id FROM people WHERE FullName = '{input}'";
            var result2 = DBConnection.Execute(sql2);
            if (result2.Count > 0 && result2[0]["Id"] != null)
            {
                return Convert.ToInt32(result2[0]["Id"]);
            }

            ServicePerson.AddNewPerson(input);

            string sql3 = $"SELECT Id FROM people WHERE SecretCode = '{input}' OR FullName = '{input}'";
            var result3 = DBConnection.Execute(sql3);
            if (result3.Count > 0 && result3[0]["Id"] != null)
            {
                return Convert.ToInt32(result3[0]["Id"]);
            }

            throw new Exception("Could not create or find person");
        }

        public static void AddPerson(string FullName, string SecretCode )
        {
            DateTime CreatedAt = DateTime.Now;
            int NumReport = 0;
            int num_mentions = 0;
            var sql = $"INSERT INTO people (FullName, SecretCode,CreatedAt,NumReport,num_mentions)" +
                       $" VALUES ('{FullName}', '{SecretCode}' ,'{CreatedAt:yyyy-MM-dd HH:mm:ss}',{NumReport},{num_mentions})";
            DBConnection.Execute(sql);
        }
        public static string GetSecretCodeByName(string FullName)
        {
            var sql = $"SELECT SecretCode FROM people WHERE FullName = '{FullName}'";
            var  CodeName = DBConnection.Execute(sql);
            if (CodeName.Count > 0 &&CodeName[0]["SecretCode"] != null)
            {
                return CodeName[0]["SecretCode"].ToString();
            }
            return "The Name Not Exists";
        }

        public static bool CheackIfFullNameExsist(string fullName)
        {
            var sql = $"SELECT Id FROM people WHERE FullName = '{fullName}'";
            var exsist = DBConnection.Execute(sql);
            return exsist != null;

        }
        public static int GetNum_mentions(int TargetId)
        {
            var Sql = $"SELECT Num_mentions FROM people WHERE Id = {TargetId}";
            var Result = DBConnection.Execute(Sql);
            return Convert.ToInt32(Result[0]["Num_mentions"]);
        }
    }
    }
