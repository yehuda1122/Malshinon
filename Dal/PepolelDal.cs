using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agents;

namespace Malshinon
{
    static class PepolelDal
    {
        public static int CheckIfExistsCodeNameOrName(string input)
        {
            string sql = $"SELECT Id FROM people WHERE SecretCode = '{input}'";
            var result = DBConnection.Execute(sql);

            if (result.Count > 0 && result[0]["id"] != null)
            {
                return Convert.ToInt32(result[0]["Id"]);
            }

            string sql2 = $"SELECT Id FROM people WHERE FullName = '{input}'";
            var result2 = DBConnection.Execute(sql2);
            if (result2.Count > 0 && result2[0]["Id"] != null)
            {
                return Convert.ToInt32(result2[0]["Id"]);
            }

            ServisForMenu.AddNewPerson(input);

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
            var sql = $"INSERT INTO people (FullName, SecretCode,CreatedAt,NumReport)" +
                       $" VALUES ('{FullName}', '{SecretCode}' ,'{CreatedAt:yyyy-MM-dd HH:mm:ss}',{NumReport})";
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
    }
}
