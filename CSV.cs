﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class CSV
    {
        public static void ImportCsv()
        {
            Console.Write("CSV file path: ");
            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) { Console.WriteLine("File not found.\n"); return; }
            int count = 0;
            var reader = new StreamReader(path);
            string header = reader.ReadLine();
            if (header == null) { Console.WriteLine("CSV is empty.\n"); return; }
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length < 4) continue;
                var reporter = parts[0];
                var target = parts[1];
                var text = parts[2];
                if (!DateTime.TryParse(parts[3], null, System.Globalization.DateTimeStyles.AssumeLocal, out var ts)) continue;
                if (string.IsNullOrWhiteSpace(reporter) || string.IsNullOrWhiteSpace(target) || string.IsNullOrWhiteSpace(text)) continue;
                int reporterId = PepolelDal.CheckIfExistsCodeNameOrName(reporter);
                int targetId = PepolelDal.CheckIfExistsCodeNameOrName(target);
                ReportDal.AddReport(reporterId, targetId, text);
                count++;
                //PepolelDal.GetNum_mentions(targetId);
            }
            //Logger.Log($"CSVImport: Imported {count} reports from {path}");
            //Console.WriteLine($"Imported {count} reports.\n");
        }
    }
}
