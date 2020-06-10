using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ProductApplication.Utilities
{
   public class Utility
    {

        public static IEnumerable<T> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
                var records = JsonSerializer.Deserialize<List<T>>(jsonString);
                return records;
        }
        public static void SaveToJson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}
